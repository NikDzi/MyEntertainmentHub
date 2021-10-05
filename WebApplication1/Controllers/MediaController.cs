using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MediaController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public MediaController(MojDbContext context, IWebHostEnvironment environment)
        {
            db = context;
            hostingEnvironment = environment;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DodajForma()
        {
            var Media = new AddMediaVM();
            Media.GenreStavke = db.Genre.Select(m => new CheckBoxItem { ID = m.GenreID, Name = m.GenreName, IsChecked = false }).ToList();
            PripremaStavki(Media);

            return View(Media);
        }
        
        public void PripremaStavki(AddMediaVM Media)
        {
            Media.MediaTypeStavke = db.MediaType.Select(m => new SelectListItem { Value = m.MediaTypeID.ToString(), Text = m.TypeName }).ToList();
            Media.CountryStavke = db.Country.Select(c => new SelectListItem { Value = c.CountryID.ToString(), Text = c.CountryName }).ToList();
            Media.LanguageStavke = db.Language.Select(l => new SelectListItem { Value = l.LanguageID.ToString(), Text = l.LanguageName }).ToList();
            Media.RatingStavke = db.Rating.Select(r => new SelectListItem { Value = r.RatingID.ToString(), Text = r.RatingName }).ToList();
            Media.CompanyStavke = db.Company.Select(c => new SelectListItem { Value = c.CompanyID.ToString(), Text = c.CompanyName }).ToList();
            Media.LocationStavke = db.Location.Select(c => new SelectListItem { Value = c.LocationID.ToString(), Text = c.LocationName }).ToList();
        }

        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int MediaID)
        {
            Media m = db.Media.Find(MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            var model = new AddMediaVM
            {
                MediaID = m.MediaID,
                MediaName = m.MediaName,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                EpisodeLength = m.EpisodeLength,
                EpisodeCount = m.EpisodeCount,
                Budget = m.Budget,
                Earnings = m.Earnings,
                MediaTypeID = m.MediaTypeID,
                CountryID = m.CountryID,
                LanguageID = m.LanguageID,
                RatingID = m.RatingID,
                GenreStavke = db.Genre.Select(m => new CheckBoxItem { ID = m.GenreID, Name = m.GenreName }).ToList(),
            };
            PripremaStavki(model);


            foreach(var x in model.GenreStavke)
            {
                if(db.MediaGenre.Any(i => i.GenreID == x.ID && i.MediaID == m.MediaID))
                {
                    x.IsChecked = true;
                }
                else
                {
                    x.IsChecked = false;
                }
            }

            return View("DodajForma", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddMediaVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                PripremaStavki(x);
                x.GenreStavke = db.Genre.Select(m => new CheckBoxItem { ID = m.GenreID, Name = m.GenreName, IsChecked = false }).ToList();
                return View("DodajForma", x);
            }
            //---

            Media m;
            List<int> Companies = new List<int>();
            if (x.ListOfCompanies != null)
            {
                Companies.AddRange(x.ListOfCompanies);
            }
            List<int> Locations = new List<int>();
            if (x.ListOfLocations != null)
            {
                Locations.AddRange(x.ListOfLocations);
            }
            List<CheckBoxItem> Genres = new List<CheckBoxItem>();
            Genres.AddRange(x.GenreStavke);

            //if (x.ListOfGenres != null)
            //{
            //    Genres.AddRange(x.ListOfGenres);
            //}

            if (x.MediaID == 0)
            {
                m = new Media();
                db.Add(m);
            }
            else
            {
                m = db.Media.Find(x.MediaID);
            }

            m.MediaName = x.MediaName;
            m.Description = x.Description;
            m.ReleaseDate = x.ReleaseDate;
            m.EpisodeLength = x.EpisodeLength;
            m.EpisodeCount = x.EpisodeCount;
            m.Budget = x.Budget;
            m.Earnings = x.Earnings;
            m.MediaTypeID = x.MediaTypeID;
            m.CountryID = x.CountryID;
            m.LanguageID = x.LanguageID;
            m.RatingID = x.RatingID;
            

            db.SaveChanges();

            if (x.MediaID == 0)
            {
                Cast cast = new Cast();
                cast.MediaID = m.MediaID;
                db.Add(cast);
                Crew crew = new Crew();
                crew.MediaID = m.MediaID;
                db.Add(crew);
                db.SaveChanges();
            }


            if (x.ListOfCompanies != null)
            {
                List<MediaCompany> ListaPostojecihComp = db.MediaCompany.Where(x => x.MediaID == m.MediaID).ToList();
                for (int i = 0; i < Companies.Count; i++)
                {
                    bool provjera = false;
                    for (int j = 0; j < ListaPostojecihComp.Count; j++)
                    {
                        if (ListaPostojecihComp[j].CompanyID == Companies[i])
                        {
                            provjera = true;
                        }
                    }
                    if (provjera == false)
                    {
                        MediaCompany mc = new MediaCompany();
                        db.Add(mc);
                        mc.CompanyID = Companies[i];
                        mc.MediaID = m.MediaID;
                    }
                }
            }
            if (Genres != null)
            {
                List<MediaGenre> ListaPostojecihGen = db.MediaGenre.Where(i => i.MediaID == x.MediaID).ToList();
                for (int i = 0; i < Genres.Count; i++)
                {
                    bool provjera = false;
                    for (int j = 0; j < ListaPostojecihGen.Count; j++)
                    {
                        if (ListaPostojecihGen[j].GenreID == Genres[i].ID)
                        {
                            provjera = true;
                            if (!Genres[i].IsChecked && x.GenreStavke.Any(l => l.ID == Genres[i].ID))
                            {
                                MediaGenre zaDelete = db.MediaGenre.Where(a => a.MediaID == x.MediaID && a.GenreID == Genres[i].ID).SingleOrDefault();
                                db.Remove(zaDelete);
                            }
                        }
                    }
                    if (provjera == false && Genres[i].IsChecked == true)
                    {
                        MediaGenre mg = new MediaGenre();
                        db.Add(mg);
                        mg.GenreID = Genres[i].ID;
                        mg.MediaID = m.MediaID;
                    }
                }
            }
            if (x.ListOfLocations != null)
            {
                List<MediaLocation> ListaPostojecihLok = db.MediaLocation.Where(x => x.MediaID == m.MediaID).ToList();
                for (int i = 0; i < Locations.Count; i++)
                {
                    bool provjera = false;
                    for (int j = 0; j < ListaPostojecihLok.Count; j++)
                    {
                        if (ListaPostojecihLok[j].LocationID == Locations[i])
                        {
                            provjera = true;
                        }
                    }
                    if (provjera == false)
                    {
                        MediaLocation ml = new MediaLocation();
                        db.Add(ml);
                        ml.LocationID = Locations[i];
                        ml.MediaID = m.MediaID;
                    }
                }
            }
            db.SaveChanges();

            TempData["ImeMedije"] = x.MediaName;
            return Redirect("/Media/DodajPoruka");
        }
        public ActionResult Prikaz()
        {
            List<MediaVM> Medias = db.Media.Select(s => new MediaVM
            {
                MediaID = s.MediaID,
                MediaName = s.MediaName,
                WatchLists=db.WatchListMedia.Where(i=>i.MediaID==s.MediaID).Select(i=> new WatchListMedia { 
                MediaID=i.MediaID,
                DateAdded=i.DateAdded,
                UserID=i.UserID,
                DateFinished=i.DateFinished,
                Media=i.Media,
                Watchstatus=i.Watchstatus,
                WatchListMediaID=i.WatchListMediaID
                }).ToList(),
                Thumbnail = db.Image.Where(i => i.MediaID == s.MediaID && i.Thumbnail == true).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).FirstOrDefault()
            }).ToList();
            return View(Medias);
        }
        public ActionResult PrikazDetaljno(int MediaID)
        {
            Media m = db.Media.Include(s => s.Country).Include(s => s.MediaType).Include(s => s.Language).Include(s => s.Rating).SingleOrDefault(s => s.MediaID == MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            string countryName;
            if(m.CountryID == null)
            {
                countryName = "N/A";
            }
            else
            {
                countryName = m.Country.CountryName;
            }
            var tech = db.TechnicalSpecifications.FirstOrDefault(i => i.MediaID == MediaID);
            string composer = "N/A";
            TechnicalSpecifications temp=new TechnicalSpecifications();
            if (tech!=null)
            {
                temp = tech;
                composer = db.SoundMix.FirstOrDefault(i => i.SoundMixID == tech.SoundMixID).Name;

            }
            var model = new MediaDetailVM
            {
                MediaID = m.MediaID,
                MediaName = m.MediaName,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate.ToString("dd/MM/yyyy"),
                EpisodeLength = m.EpisodeLength,
                EpisodeCount = m.EpisodeCount,
                Budget = m.Budget,
                Earnings = m.Earnings,
                MediaType = m.MediaType.TypeName,
                Country = countryName,
                Language = m.Language.LanguageName,
                Rating = m.Rating.RatingName,
                composer=composer,
                CrewStavke = db.CrewPerson.Where(c => c.Crew.MediaID == MediaID).Select(p => new CrewPersonVM
                {
                    CrewPersonID = p.CrewPersonID,
                    CrewID = p.CrewID,
                    MediaID = p.Crew.MediaID,
                    PersonID = p.PersonID,
                    PersonFirstName = p.Person.FirstName,
                    PersonLastName = p.Person.LastName,
                    OccupationID = p.OccupationID,
                    OccupationName = p.Occupation.OccupationName
                }).ToList(),
                CastStavke = db.CastPerson.Where(c => c.Cast.MediaID == MediaID).Select(p => new CastPersonVM
                {
                    CastPersonID = p.CastPersonID,
                    CastID = p.CastID,
                    MediaID = p.Cast.MediaID,
                    PersonID = p.PersonID,
                    PersonFirstName = p.Person.FirstName,
                    PersonLastName = p.Person.LastName,
                    CharacterID = p.CharacterID,
                    CharacterFirstName = p.Character.FirstName,
                    CharacterLastName = p.Character.LastName
                }).ToList(),
                CompanyStavke = db.MediaCompany.Where(c => c.MediaID == MediaID).Select(p => new CompanyVM
                {
                    CompanyID = p.Company.CompanyID,
                    CompanyName = p.Company.CompanyName,
                    CompanyType = p.Company.CompanyType.TypeName
                }).ToList(),
                LocationStavke = db.MediaLocation.Where(c => c.MediaID == MediaID).Select(p => new LocationVM
                {
                    LocationID = p.Location.LocationID,
                    LocationName = p.Location.LocationName,
                    CityID = p.Location.City.CityID,
                    CityName = p.Location.City.CityName
                }).ToList(),
                GenreStavke = db.MediaGenre.Where(c => c.MediaID == MediaID).Select(p => new Genre
                {
                    GenreID = p.Genre.GenreID,
                    GenreName = p.Genre.GenreName
                }).ToList(),
                ImageList = db.Image.Where(i => i.MediaID == MediaID).Select(i => new ImageVM
                {
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    MediaID = i.MediaID,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).ToList(),
                Comments = db.Comments.Where(i => i.MediaID == MediaID).Select(i => new AddCommentVM
                {
                    CommentID = i.CommentID,
                    CommentContent=i.CommentContent,
                    DateOfCreation=i.DateOfCreation,
                    Score=i.Score,
                    MediaID=i.MediaID,
                    UserID=i.UserID,                   
                    User=i.User,
                    Media=i.Media,
                    RUIDS=i.RUID,
                    Reports=i.Reports
                    
                }).ToList(),
                
            };
            if (temp!=null)
            {
                model.TechnicalSpecifications = temp;
                model.TechnicalSpecificationsID = temp.TechnicalSpecificationsID;
            }

            model.Comments.Reverse();
            

            return View("PrikazDetaljno", model);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int MediaID)
        {
            List<CrewPerson> ZaBrisatiCrew = db.CrewPerson.Where(i => i.Crew.MediaID == MediaID).ToList();
            db.RemoveRange(ZaBrisatiCrew);
            List<CastPerson> ZaBrisatiCast = db.CastPerson.Where(i => i.Cast.MediaID == MediaID).ToList();
            db.RemoveRange(ZaBrisatiCast);
            Crew Crew = db.Crew.Where(i => i.MediaID == MediaID).SingleOrDefault();
            db.Remove(Crew);
            Cast Cast = db.Cast.Where(i => i.MediaID == MediaID).SingleOrDefault();
            db.Remove(Cast);
            List<MediaGenre> ZaBrisatiGenre = db.MediaGenre.Where(i => i.MediaID == MediaID).ToList();
            db.RemoveRange(ZaBrisatiGenre);
            List<MediaCompany> ZaBrisatiCompany = db.MediaCompany.Where(i => i.MediaID == MediaID).ToList();
            db.RemoveRange(ZaBrisatiCompany);
            List<MediaLocation> ZaBrisatiLocation = db.MediaLocation.Where(i => i.MediaID == MediaID).ToList();
            db.RemoveRange(ZaBrisatiLocation);

            List<Image> ZaBrisatiSlike = db.Image.Where(s => s.MediaID == MediaID).ToList();
            ImageDeleteHelper brisac = new ImageDeleteHelper(db);
            brisac.IzbrisiSlike(ZaBrisatiSlike, hostingEnvironment);

            db.RemoveRange(ZaBrisatiSlike);

            Media m = db.Media.Find(MediaID);

            TempData["ImeMedia"] = m.MediaName;
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/Media/BrisanjePoruka");
        }
        public ActionResult BrisanjePoruka()
        {
            return Redirect("/Media/Prikaz");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        public ActionResult CrewEdit(int MediaID)
        {
            var Media = db.Media.Find(MediaID);

            var model = new AddCrewPersonVM
            {
                MediaID = Media.MediaID,
                MediaName = Media.MediaName,
                PersonStavke = db.Person.Select(p => new SelectListItem { Value = p.PersonID.ToString(), Text = p.FirstName + " " + p.LastName, Selected = false }).ToList(),
                OccupationStavke = db.Occupation.Where(o => o.OccupationName != "Actor" ).Select(o => new SelectListItem { Value = o.OccupationID.ToString(), Text = o.OccupationName, Selected = false }).ToList()
            };
            return View(model);
        }
        public ActionResult CrewTable(int MediaID)
        {
            Media m = db.Media.Include(s => s.Country).Include(s => s.MediaType).Include(s => s.Language).Include(s => s.Rating).SingleOrDefault(s => s.MediaID == MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            var model = new MediaDetailVM
            {
                CrewStavke = db.CrewPerson.Where(c => c.Crew.MediaID == MediaID).Select(p => new CrewPersonVM
                {
                    CrewPersonID = p.CrewPersonID,
                    CrewID = p.CrewID,
                    MediaID = p.Crew.MediaID,
                    PersonID = p.PersonID,
                    PersonFirstName = p.Person.FirstName,
                    PersonLastName = p.Person.LastName,
                    OccupationID = p.OccupationID,
                    OccupationName = p.Occupation.OccupationName
                }).ToList()
            };

            return PartialView(model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiCrewEdit(AddCrewPersonVM x)
        {
            var ProvjeraCrew = db.CrewPerson.Where(i => i.OccupationID == x.OccupationID && i.PersonID == x.PersonID && i.Crew.MediaID == x.MediaID).FirstOrDefault();
            var Media = db.Media.Include(c => c.Crew).SingleOrDefault(i => i.MediaID == x.MediaID);

            if (ProvjeraCrew != null)
            {

                return Redirect("/Media/CrewEdit?MediaID=" + Media.MediaID);
            }
            else
            {
                CrewPerson cp = new CrewPerson();
                db.Add(cp);

                cp.CrewID = Media.Crew.CrewID;
                cp.PersonID = x.PersonID;
                cp.OccupationID = x.OccupationID;

                db.SaveChanges();
            }
            
            return Redirect("/Media/CrewEdit?MediaID=" + Media.MediaID);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisanjeCrew(int CrewPersonID)
        {
            CrewPerson cp = db.CrewPerson.Include(c => c.Crew).SingleOrDefault(i => i.CrewPersonID == CrewPersonID);
            int tempMediaID = cp.Crew.MediaID;
            db.Remove(cp);
            db.SaveChanges();
            return Redirect("/Media/CrewEdit?MediaID=" + tempMediaID);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        public ActionResult CastEdit(int MediaID)
        {
            var Media = db.Media.Find(MediaID);
            var model = new AddCastPersonVM
            {
                MediaID = Media.MediaID,
                MediaName = Media.MediaName,
                PersonStavke = db.Person.Select(p => new SelectListItem { Value = p.PersonID.ToString(), Text = p.FirstName + " " + p.LastName, Selected = false }).ToList(),
                CharacterStavke = db.Character.Select(c => new SelectListItem { Value = c.CharacterID.ToString(), Text = c.FirstName + " " + c.LastName, Selected = false }).ToList()
            };

            return View(model);
        }
        public ActionResult CastTable(int MediaID)
        {
            Media m = db.Media.Include(s => s.Country).Include(s => s.MediaType).Include(s => s.Language).Include(s => s.Rating).SingleOrDefault(s => s.MediaID == MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            var model = new MediaDetailVM
            {
                CastStavke = db.CastPerson.Where(c => c.Cast.MediaID == MediaID).Select(p => new CastPersonVM
                {
                    CastPersonID = p.CastPersonID,
                    CastID = p.CastID,
                    MediaID = p.Cast.MediaID,
                    PersonID = p.PersonID,
                    PersonFirstName = p.Person.FirstName,
                    PersonLastName = p.Person.LastName,
                    CharacterID = p.CharacterID,
                    CharacterFirstName = p.Character.FirstName,
                    CharacterLastName = p.Character.LastName
                }).ToList()
            };

            return PartialView(model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiCastEdit(AddCastPersonVM x)
        {
            var ProvjeraCast = db.CastPerson.Where(i => i.PersonID == x.PersonID && i.CharacterID == x.CharacterID && i.Cast.MediaID == x.MediaID).FirstOrDefault();
            var Media = db.Media.Include(c => c.Cast).SingleOrDefault(i => i.MediaID == x.MediaID);

            if (ProvjeraCast != null)
            {
                return Redirect("/Media/CastEdit?MediaID=" + Media.MediaID);
            }
            else 
            {
                CastPerson cp = new CastPerson();
                db.Add(cp);

                cp.CastID = Media.Cast.CastID;
                cp.PersonID = x.PersonID;
                cp.CharacterID = x.CharacterID;

                db.SaveChanges();
            }
            
            return Redirect("/Media/CastEdit?MediaID=" + Media.MediaID);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisanjeCast(int CastPersonID)
        {
            CastPerson cp = db.CastPerson.Include(c => c.Cast).SingleOrDefault(i => i.CastPersonID == CastPersonID);
            int tempMediaID = cp.Cast.MediaID;
            db.Remove(cp);
            db.SaveChanges();
            return Redirect("/Media/CastEdit?MediaID=" + tempMediaID);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        public ActionResult CompanyEdit(int MediaID)
        {
            var Media = db.Media.Find(MediaID);

            var model = new AddMediaCompanyVM
            {
                MediaID = Media.MediaID,
                MediaName = Media.MediaName,
                CompanyStavke = db.Company.Select(c => new SelectListItem { Value = c.CompanyID.ToString(), Text = c.CompanyName, Selected = false }).ToList()
            };
            return View(model);
        }
        public ActionResult CompanyTable(int MediaID)
        {
            Media m = db.Media.Include(s => s.Country).Include(s => s.MediaType).Include(s => s.Language).Include(s => s.Rating).SingleOrDefault(s => s.MediaID == MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            var model = new MediaDetailVM
            {
                CompanyStavke = db.MediaCompany.Where(c => c.MediaID == m.MediaID).Select(c => new CompanyVM
                {
                    CompanyID = c.CompanyID,
                    CompanyName = c.Company.CompanyName,
                    CompanyType = c.Company.CompanyType.TypeName,
                    MediaCompanyID = c.MediaCompanyID
                }).ToList()
            };

            return PartialView(model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiCompanyEdit(AddMediaCompanyVM x)
        {
            var MediaComp = db.MediaCompany.SingleOrDefault(i => i.MediaID == x.MediaID && i.CompanyID == x.CompanyID);
            if (MediaComp == null)
            {
                MediaCompany mc = new MediaCompany();
                db.Add(mc);
                mc.CompanyID = x.CompanyID;
                mc.MediaID = x.MediaID;
                db.SaveChanges();
            }
            else
            {
                return Redirect("/Media/CompanyEdit?MediaID=" + x.MediaID);
            }

            return Redirect("/Media/CompanyEdit?MediaID=" + x.MediaID);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisanjeCompany(int MediaCompanyID)
        {
            MediaCompany mc = db.MediaCompany.Find(MediaCompanyID);
            int tempMediaID = mc.MediaID;
            db.Remove(mc);
            db.SaveChanges();
            return Redirect("/Media/CompanyEdit?MediaID=" + tempMediaID);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        public ActionResult LocationEdit(int MediaID)
        {
            var Media = db.Media.Find(MediaID);

            var model = new AddMediaLocationVM
            {
                MediaID = Media.MediaID,
                MediaName = Media.MediaName,
                LocationStavke = db.Location.Select(c => new SelectListItem { Value = c.LocationID.ToString(), Text = c.LocationName, Selected = false }).ToList()
            };
            return View(model);
        }
        public ActionResult LocationTable(int MediaID)
        {
            Media m = db.Media.Include(s => s.Country).Include(s => s.MediaType).Include(s => s.Language).Include(s => s.Rating).SingleOrDefault(s => s.MediaID == MediaID);
            if (m == null)
                return RedirectToAction("Prikaz");

            var model = new MediaDetailVM
            {
                LocationStavke = db.MediaLocation.Where(l => l.MediaID == m.MediaID).Select(l => new LocationVM
                {
                    LocationID = l.LocationID,
                    LocationName = l.Location.LocationName,
                    CityID = l.Location.CityID,
                    CityName = l.Location.City.CityName,
                    MediaLocationID = l.MediaLocationID
                }).ToList()
            };

            return PartialView(model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiLocationEdit(AddMediaLocationVM x)
        {
            var MediaLoc = db.MediaLocation.SingleOrDefault(i => i.MediaID == x.MediaID && i.LocationID == x.LocationID);
            if (MediaLoc == null)
            {
                MediaLocation mc = new MediaLocation();
                db.Add(mc);
                mc.LocationID = x.LocationID;
                mc.MediaID = x.MediaID;
                db.SaveChanges();
            }
            else
            {
                return Redirect("/Media/LocationEdit?MediaID=" + x.MediaID);
            }

            return Redirect("/Media/LocationEdit?MediaID=" + x.MediaID);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisanjeLocation(int MediaLocationID)
        {
            MediaLocation ml = db.MediaLocation.Find(MediaLocationID);
            int tempMediaID = ml.MediaID;
            db.Remove(ml);
            db.SaveChanges();
            return Redirect("/Media/LocationEdit?MediaID=" + tempMediaID);
        }

        public IActionResult DodajSpecs(int MediaID, int TechnicalSpecificationsID)
        {
            var m = db.Media.Find(MediaID);
            m.TechnicalSpecificationsID = TechnicalSpecificationsID;
            db.SaveChanges();
            return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = MediaID });
        }
    }
}

