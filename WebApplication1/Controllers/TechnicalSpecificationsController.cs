using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class TechnicalSpecificationsController : Controller
    {
        private readonly MojDbContext db;
        public TechnicalSpecificationsController(MojDbContext context)
        {
            db = context;
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult DodajForma(int MediaID)
        {
            if (db.TechnicalSpecifications.Any(i => i.MediaID == MediaID))
            {
                return View("DodajPoruka");

            }
            var model = new TechnicalSpecificationsVM()
            {
                MediaID=MediaID,
                ColorStavke = db.Color.Select(c => new SelectListItem { Value = c.ColorID.ToString(), Text = c.ColorName }).ToList()
            };
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult SnimiForma(TechnicalSpecificationsVM x)
        {
            if (!ModelState.IsValid)
            {
                x.ColorStavke = db.Color.Select(c => new SelectListItem { Value = c.ColorID.ToString(), Text = c.ColorName }).ToList();

                return View("DodajForma", x);
            }
            if (db.TechnicalSpecifications.Any(i=>i.TechnicalSpecificationsID==x.TechnicalSpecificationsID))
            {
                var t = db.TechnicalSpecifications.Find(x.TechnicalSpecificationsID);
                t.MediaID = x.MediaID;
                t.AspectRatio = x.AspectRatio;
                t.Camera = x.Camera;
                t.Laboratory = x.Laboratory;
                t.NegativeFormat = x.NegativeFormat;
                t.CinematographicProcess = x.CinematographicProcess;
                t.PrintedFilmFormat = x.PrintedFilmFormat;
                t.ColorID = x.ColorID;
                t.SoundMixID = x.SoundMixID;
                db.SaveChanges();
                return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = t.MediaID });


            }

            SoundMix mix = new SoundMix { Name = x.SoundComposer };
            db.Add(mix);
            db.SaveChanges();

            TechnicalSpecifications spec = new TechnicalSpecifications()
            {
                MediaID=x.MediaID,
                AspectRatio=x.AspectRatio,
                Camera=x.Camera,
                Laboratory=x.Laboratory,
                NegativeFormat=x.NegativeFormat,
                CinematographicProcess=x.CinematographicProcess,
                PrintedFilmFormat=x.PrintedFilmFormat,
                ColorID=x.ColorID,
                SoundMixID=mix.SoundMixID
            };
            db.Add(spec);
            db.SaveChanges();
            return RedirectToAction("DodajSpecs", "Media",new {MediaID=x.MediaID, TechnicalSpecificationsID = spec.TechnicalSpecificationsID });
        }
        public IActionResult ViewSpecs(int MediaID)
        {
            var temp = db.TechnicalSpecifications.FirstOrDefault(i => i.MediaID == MediaID);
            var model = new TechnicalSpecificationsVM
            {
                TechnicalSpecificationsID = temp.TechnicalSpecificationsID,
                AspectRatio = temp.AspectRatio,
                Camera = temp.Camera,
                Laboratory = temp.Laboratory,
                CinematographicProcess=temp.CinematographicProcess,
                Color=db.Color.Find(temp.ColorID),
                ColorID=temp.ColorID,
                SoundMix=db.SoundMix.Find(temp.SoundMixID),
                SoundMixID=temp.SoundMixID,
                SoundComposer=db.SoundMix.Find(temp.SoundMixID).Name,
                NegativeFormat=temp.NegativeFormat,
                PrintedFilmFormat=temp.PrintedFilmFormat,
                MediaID=MediaID
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int TechnicalSpecificationsID)
        {
            var x = db.TechnicalSpecifications.Find(TechnicalSpecificationsID);
            var med = db.Media.FirstOrDefault(i => i.MediaID == x.MediaID);
            db.Remove(x);
            db.SaveChanges();
            TempData["Deleted"] = med.MediaName;
            return View("DeletePoruka");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int TechnicalSpecificationsID)
        {
            var x = db.TechnicalSpecifications.Find(TechnicalSpecificationsID);
            var model = new TechnicalSpecificationsVM()
            {
                TechnicalSpecificationsID=x.TechnicalSpecificationsID,
                Color=x.Color,
                ColorID=x.ColorID,
                SoundMixID=x.SoundMixID,
                MediaID = x.MediaID,
                ColorStavke = db.Color.Select(c => new SelectListItem { Value = c.ColorID.ToString(), Text = c.ColorName }).ToList()
            };
            return View("DodajForma",model);
 
        }
        //public IActionResult Prikaz(int MediaID)
        //{
        //    return View(model)
        //}
    }
}
