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
    public class CityController : Controller
    {
        private readonly MojDbContext db;
        public CityController(MojDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DodajForma()
        {
            var model = new AddCityVM()
            {
                CountryStavke = db.Country.Select(c => new SelectListItem { Value = c.CountryID.ToString(), Text = c.CountryName }).ToList()
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int CityID)
        {
            City c = db.City.Find(CityID);
            if (c == null)
                return RedirectToAction("Prikaz");

            var model = new AddCityVM
            {
                CityID = c.CityID,
                CityName = c.CityName,
                CountryID = c.CountryID
            };

            model.CountryStavke = db.Country.Select(c => new SelectListItem { Value = c.CountryID.ToString(), Text = c.CountryName }).ToList();

            return View("DodajForma", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddCityVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                x.CountryStavke = db.Country.Select(c => new SelectListItem { Value = c.CountryID.ToString(), Text = c.CountryName }).ToList();
                return View("DodajForma", x);
            }
            //---

            City c;
            if (x.CityID == 0)
            {
                c = new City();
                db.Add(c);
            }
            else
            {
                c = db.City.Find(x.CityID);
            }

            c.CityName = x.CityName;
            c.CountryID = x.CountryID;

            db.SaveChanges();

            TempData["ImeGrada"] = x.CityName;
            return Redirect("/City/DodajPoruka");
        }
        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Prikaz()
        {
            List<CityVM> Cities = db.City.Select(c => new CityVM
            {
                CityID = c.CityID,
                CityName = c.CityName,
                Country = c.Country.CountryName
            }).ToList();
            return View(Cities);
        }
    }
}