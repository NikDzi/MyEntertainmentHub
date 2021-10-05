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
using System.Globalization;

namespace WebApplication1.Controllers
{
    public class LocationController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public LocationController(MojDbContext context, IWebHostEnvironment environment)
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
            var Location = new AddLocationVM();
            PripremaStavki(Location);
            return View(Location);
        }

        public void PripremaStavki(AddLocationVM Location)
        {
            Location.CityStavke = db.City.Select(c => new SelectListItem { Value = c.CityID.ToString(), Text = c.CityName + ", " + c.Country.CountryName }).ToList();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int LocationID)
        {
            Location l = db.Location.Find(LocationID);
            if (l == null)
                return RedirectToAction("Prikaz");

            var model = new AddLocationVM
            {

                LocationID = l.LocationID,
                LocationName = l.LocationName,
                Description = l.Description,
                CityID = l.CityID,
                Latitude = l.Latitude.ToString(),
                Longitude = l.Longitude.ToString()
            };
            PripremaStavki(model);

            return View("DodajForma", model);
        }
        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddLocationVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                PripremaStavki(x);
                return View("DodajForma", x);
            }
            //---

            Location l;
            if (x.LocationID == 0)
            {
                l = new Location();
                db.Add(l);
            }
            else
            {
                l = db.Location.Find(x.LocationID);
            }

            l.LocationName = x.LocationName;
            l.CityID = x.CityID;
            l.Description = x.Description;
            //l.Latitude = x.Latitude;
            //l.Latitude = Convert.ToDecimal(x.Latitude);
            if (x.Latitude == null) 
            {
                l.Latitude = null;
            }
            else
            {
                l.Latitude = Decimal.Parse(x.Latitude, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            //l.Longitude = x.Longitude;
            //l.Longitude = Convert.ToDecimal(x.Longitude);
            if (x.Longitude == null)
            {
                l.Longitude = null;
            }
            else
            {
                l.Longitude = Decimal.Parse(x.Longitude, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }

            db.SaveChanges();
            TempData["ImeLokacije"] = x.LocationName;
            return Redirect("/Location/DodajPoruka");
        }
        public ActionResult Prikaz()
        {
            List<LocationVM> Locations = db.Location.Select(l => new LocationVM
            {
                LocationID = l.LocationID,
                LocationName = l.LocationName,
                Thumbnail = db.Image.Where(i => i.LocationID == l.LocationID && i.Thumbnail == true).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).FirstOrDefault()
            }).ToList();
            return View(Locations);
        }
        public ActionResult PrikazDetaljno(int LocationID)
        {
            Location l = db.Location.Include(s => s.City).SingleOrDefault(s => s.LocationID == LocationID);
            if (l == null)
                return RedirectToAction("Index");

            //string valueLat;
            //string valueLon;
            //if (l.Latitude != null)
            //{
            //    //valueLat = l.Latitude.Value.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
            //    valueLat = l.Latitude.Value.ToString();
            //}
            //else
            //{
            //    valueLat = null;
            //}
            //if (l.Longitude != null)
            //{
            //    //valueLon = l.Longitude.Value.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
            //    valueLon = l.Longitude.Value.ToString();
            //}
            //else
            //{
            //    valueLon = null;
            //}

            var model = new LocationDetailVM
            {
                LocationID = l.LocationID,
                LocationName = l.LocationName,
                City = l.City.CityName,
                Description = l.Description,
                MediaLocationStavke = db.MediaLocation.Where(l => l.LocationID == LocationID).Select(l => new MediaLocationVM
                {
                    MediaLocationID = l.MediaLocationID,
                    LocationID = l.LocationID,
                    LocationName = l.Location.LocationName,
                    LocationCity = l.Location.City.CityName,
                    MediaID = l.MediaID,
                    MediaName = l.Media.MediaName,
                    MediaType = l.Media.MediaType.TypeName
                }).ToList(),
                ImageList = db.Image.Where(i => i.LocationID == LocationID).Select(i => new ImageVM
                {
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    LocationID = i.LocationID,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).ToList()
            };

            if (l.Latitude != null)
            {
                //model.Latitude = valueLat;
                model.Latitude = l.Latitude.Value.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture); ;
            }
            if (l.Latitude != null)
            {
                //model.Longitude = valueLon;
                model.Longitude = l.Longitude.Value.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
            }

            return View("PrikazDetaljno", model);
        }

        [Authorize(Roles = "Admin")] // treba provjerit je li potrebno!
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int LocationID)
        {
            List<MediaLocation> ZaBrisati = db.MediaLocation.Where(s => s.LocationID == LocationID).ToList();
            db.RemoveRange(ZaBrisati);

            List<Image> ZaBrisatiSlike = db.Image.Where(s => s.LocationID == LocationID).ToList();
            ImageDeleteHelper brisac = new ImageDeleteHelper(db);
            brisac.IzbrisiSlike(ZaBrisatiSlike, hostingEnvironment);

            db.RemoveRange(ZaBrisatiSlike);

            Location l = db.Location.Find(LocationID);

            TempData["ImeLokacije"] = l.LocationName;
            db.Remove(l);
            db.SaveChanges();
            return Redirect("/Location/BrisanjePoruka");
        }
        public ActionResult BrisanjePoruka()
        {
            return View();
        }
    }
}