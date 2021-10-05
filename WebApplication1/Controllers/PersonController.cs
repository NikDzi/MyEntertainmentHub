using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.Model;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using WebApplication1.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public PersonController(MojDbContext context, IWebHostEnvironment environment)
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
            var Person = new AddPersonVM();

            PripremaStavki(Person);

            return View(Person);
        }
        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }

        public void PripremaStavki(AddPersonVM Person)
        {
            Person.CityStavke = db.City.Select(c => new SelectListItem { Value = c.CityID.ToString(), Text = c.CityName + ", " + c.Country.CountryName }).ToList();
            Person.OccupationStavke = db.Occupation.Select(o => new CheckBoxItem { ID = o.OccupationID, Name = o.OccupationName, IsChecked = false }).ToList();
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddPersonVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                PripremaStavki(x);
                return View("DodajForma", x);
            }
            //---

            Person p;
            List<CheckBoxItem> Occupations = new List<CheckBoxItem>();
            Occupations.AddRange(x.OccupationStavke);

            if (x.PersonID == 0)
            {
                p = new Person();
                db.Add(p);

            }
            else
            {
                p = db.Person.Find(x.PersonID);
            }

            p.FirstName = x.FirstName;
            p.LastName = x.LastName;
            p.DateOfBirth = x.DateOfBirth;
            p.DateOfDeath = x.DateOfDeath;
            p.CityID = x.CityID;

            db.SaveChanges();

            if (Occupations != null)
            {
                List<PersonOccupation> ListaPostojecihPO = db.PersonOccupation.Where(s => s.PersonID == p.PersonID).ToList();
                for (int i = 0; i < Occupations.Count; i++)
                {
                    bool provjera = false;
                    for (int j = 0; j < ListaPostojecihPO.Count; j++)
                    {
                        if (ListaPostojecihPO[j].OccupationID == Occupations[i].ID)
                        {
                            provjera = true;
                            if (!Occupations[i].IsChecked && x.OccupationStavke.Any(l => l.ID == Occupations[i].ID))
                            {
                                PersonOccupation zaDelete = db.PersonOccupation.Where(a => a.PersonID == x.PersonID && a.OccupationID == Occupations[i].ID).SingleOrDefault();
                                db.Remove(zaDelete);
                            }
                        }
                    }
                    if (provjera == false && Occupations[i].IsChecked == true)
                    {
                        PersonOccupation po = new PersonOccupation();
                        db.Add(po);
                        po.OccupationID = Occupations[i].ID;
                        po.PersonID = p.PersonID;
                    }
                }
            }

            db.SaveChanges();
            TempData["ImeOsobe"] = x.FirstName + " " + x.LastName;
            return Redirect("/Person/DodajPoruka");
        }
        public ActionResult Prikaz()
        {
            List<PersonVM> People = db.Person.Select(p => new PersonVM
            {
                PersonID = p.PersonID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Thumbnail = db.Image.Where(i => i.PersonID == p.PersonID && i.Thumbnail == true).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).FirstOrDefault()
            }).ToList();
            return View(People);
        }
        public ActionResult PrikazDetaljno(int PersonID)
        {
            Person p = db.Person.Include(s => s.City).Include(s => s.City.Country).SingleOrDefault(s => s.PersonID == PersonID);
            if (p == null)
                return RedirectToAction("Prikaz");
            string cityName;
            string countryName;
            if (p.CityID == null)
            {
               cityName = "N/A";
               countryName = "";
            }
            else
            {
                cityName = p.City.CityName;
                countryName = p.City.Country.CountryName;
            }

            string DoD;
            if (p.DateOfDeath != null)
            {
                DoD = p.DateOfDeath.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                DoD = "N/A";
            }

            var model = new PersonDetailVM
            {
                PersonID = p.PersonID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Country = countryName,
                City = cityName,
                DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
                DateOfDeath = DoD,
                CrewPersonStavke = db.CrewPerson.Where(p => p.PersonID == PersonID).Select(p => new CrewPersonVM
                {
                    CrewPersonID = p.CrewPersonID,
                    CrewID = p.CrewID,
                    MediaID = p.Crew.MediaID,
                    MediaName = p.Crew.Media.MediaName,
                    PersonID = p.PersonID,
                    OccupationID = p.OccupationID,
                    OccupationName = p.Occupation.OccupationName
                }).ToList(),
                CastPersonStavke = db.CastPerson.Where(p => p.PersonID == PersonID).Select(p => new CastPersonVM
                {
                    CastPersonID = p.CastPersonID,
                    CastID = p.CastID,
                    MediaID = p.Cast.MediaID,
                    MediaName = p.Cast.Media.MediaName,
                    PersonID = p.PersonID,
                    CharacterFirstName = p.Character.FirstName,
                    CharacterLastName = p.Character.LastName,
                    CharacterID = p.CharacterID
                }).ToList(),
                PersonOccupationStavke = db.PersonOccupation.Where(p => p.PersonID == PersonID).Select(p => new PersonOccupationVM
                {
                    PersonOccupationID = p.PersonOccupationID,
                    PersonID = p.PersonID,
                    OccupationID = p.OccupationID,
                    OccupationName = p.Occupation.OccupationName
                }).ToList(),
                ImageList = db.Image.Where(i => i.PersonID == PersonID).Select(i => new ImageVM
                {
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    PersonID = i.PersonID,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).ToList()

            };

            return View("PrikazDetaljno", model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int PersonID)
        {
            Person p = db.Person.Find(PersonID);
            if (p == null)
                return RedirectToAction("Prikaz");

            var model = new AddPersonVM
            {
                PersonID = p.PersonID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                DateOfDeath = p.DateOfDeath,
                CityID = p.CityID,
                CityStavke = db.City.Select(c => new SelectListItem { Value = c.CityID.ToString(), Text = c.CityName + ", " + c.Country.CountryName }).ToList(),
                OccupationStavke = db.Occupation.Select(o => new CheckBoxItem { ID = o.OccupationID, Name = o.OccupationName }).ToList()
            };

            foreach (var x in model.OccupationStavke)
            {
                if (db.PersonOccupation.Any(i => i.OccupationID == x.ID && i.PersonID == model.PersonID))
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
        [Authorize(Roles = "Admin")] // treba provjerit je li potrebno!
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int PersonID)
        {
            List<CrewPerson> ZaBrisatiCrew = db.CrewPerson.Where(s => s.PersonID == PersonID).ToList();
            db.RemoveRange(ZaBrisatiCrew);
            List<CastPerson> ZaBrisatiCast = db.CastPerson.Where(s => s.PersonID == PersonID).ToList();
            db.RemoveRange(ZaBrisatiCast);
            List<PersonOccupation> ZaBrisatiOccupation = db.PersonOccupation.Where(s => s.PersonID == PersonID).ToList();
            db.RemoveRange(ZaBrisatiOccupation);

            List<Image> ZaBrisatiSlike = db.Image.Where(s => s.PersonID == PersonID).ToList();
            ImageDeleteHelper brisac = new ImageDeleteHelper(db);
            brisac.IzbrisiSlike(ZaBrisatiSlike, hostingEnvironment);

            db.RemoveRange(ZaBrisatiSlike);

            Person p = db.Person.Find(PersonID);

            TempData["ImeOsobe"] = p.FirstName + " " + p.LastName;
            db.Remove(p);
            db.SaveChanges();
            return Redirect("/Person/BrisanjePoruka");
        }
        public ActionResult BrisanjePoruka()
        {
            return View();
        }
    }
}