using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ColorController : Controller
    {
        private readonly MojDbContext db;
        public ColorController(MojDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var model = db.Color.ToList();
            return View(model);
        }
        public IActionResult DodajForma()
        {
            var model = new AddColorVM { };
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public IActionResult SnimiForma(AddColorVM x)
        {
            if (db.Color.Any(i=>i.ColorID==x.ColorID))
            {
                var cl = db.Color.Find(x.ColorID);
                cl.ColorName = x.ColorName;
                db.SaveChanges();
                TempData["Color"] = cl.ColorName;
                return View("DodajPoruka");
            }
            var color = new Color
            {
                ColorName = x.ColorName
            };
            db.Add(color);
            db.SaveChanges();
            TempData["Color"] = color.ColorName;
            return View("DodajPoruka");
        }
        public IActionResult Edit(int ColorID)
        {
            var cl = db.Color.Find(ColorID);
            var model = new AddColorVM
            {
                ColorID = cl.ColorID,
                ColorName = cl.ColorName
            };
            return View("DodajForma", model);
        }
    }
}
