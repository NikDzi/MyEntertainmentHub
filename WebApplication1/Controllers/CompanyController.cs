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
    public class CompanyController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CompanyController(MojDbContext context, IWebHostEnvironment environment)
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
            var Company = new AddCompanyVM();
            PripremaStavki(Company);
            return View(Company);
        }

        //--- helper radi ponavljanja koda
        public void PripremaStavki(AddCompanyVM Company)
        {
            Company.CompanyTypeStavke = db.CompanyType.Select(c => new SelectListItem { Value = c.CompanyTypeID.ToString(), Text = c.TypeName }).ToList();
            Company.CityStavke = db.City.Select(c => new SelectListItem { Value = c.CityID.ToString(), Text = c.CityName + ", " + c.Country.CountryName }).ToList();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int CompanyID)
        {
            Company c = db.Company.Find(CompanyID);
            if (c == null)
                return RedirectToAction("Prikaz");

            var model = new AddCompanyVM
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName,
                CompanyTypeID = c.CompanyTypeID,
                CityID = c.CityID,
                Description = c.Description
            };

            PripremaStavki(model);

            return View("DodajForma", model);
        }
        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddCompanyVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                PripremaStavki(x);
                return View("DodajForma", x);
            }
            //---

            Company c;
            if (x.CompanyID == 0)
            {
                c = new Company();
                db.Add(c);
            }
            else
            {
                c = db.Company.Find(x.CompanyID);
            }

            c.CompanyName = x.CompanyName;
            c.CompanyTypeID = x.CompanyTypeID;
            c.CityID = x.CityID;
            c.Description = x.Description;

            db.SaveChanges();
            TempData["ImeKompanije"] = x.CompanyName;
            return Redirect("/Company/DodajPoruka");
        }
        public ActionResult Prikaz()
        {
            List<CompanyVM> Companies = db.Company.Select(c => new CompanyVM
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName,
                CompanyType = c.CompanyType.TypeName,
                Thumbnail = db.Image.Where(i => i.CompanyID == c.CompanyID && i.Thumbnail == true).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).FirstOrDefault()
            }).ToList();
            return View(Companies);
        }
        public ActionResult PrikazDetaljno(int CompanyID)
        {
            Company c = db.Company.Include(s => s.CompanyType).Include(s => s.City).Include(s => s.City.Country).SingleOrDefault(s => s.CompanyID == CompanyID);
            if (c == null)
                return RedirectToAction("Prikaz");

            var model = new CompanyDetailVM
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName,
                CompanyType = c.CompanyType.TypeName,
                City = c.City.CityName,
                Country = c.City.Country.CountryName,
                Description = c.Description,
                MediaCompanyStavke = db.MediaCompany.Where(c => c.CompanyID == CompanyID).Select(c => new MediaCompanyVM
                {
                    MediaCompanyID = c.MediaCompanyID,
                    CompanyID = c.CompanyID,
                    MediaID = c.MediaID,
                    MediaName = c.Media.MediaName,
                    MediaType = c.Media.MediaType.TypeName,
                }).ToList(),
                ImageList = db.Image.Where(i => i.CompanyID == CompanyID).Select(i => new ImageVM
                {
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    CompanyID = i.CompanyID,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).ToList()
            };

            return View("PrikazDetaljno", model);
        }
        [Authorize(Roles = "Admin")] // treba provjerit je li potrebno!
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int CompanyID)
        {
            List<MediaCompany> ZaBrisati = db.MediaCompany.Where(s => s.CompanyID == CompanyID).ToList();
            db.RemoveRange(ZaBrisati);

            List<Image> ZaBrisatiSlike = db.Image.Where(s => s.CompanyID == CompanyID).ToList();
            ImageDeleteHelper brisac = new ImageDeleteHelper(db);
            brisac.IzbrisiSlike(ZaBrisatiSlike, hostingEnvironment);

            db.RemoveRange(ZaBrisatiSlike);

            Company c = db.Company.Find(CompanyID);

            TempData["ImeKompanije"] = c.CompanyName;
            db.Remove(c);
            db.SaveChanges();
            return Redirect("/Company/BrisanjePoruka");
        }

        public ActionResult BrisanjePoruka()
        {
            return View();
        }
    }
}