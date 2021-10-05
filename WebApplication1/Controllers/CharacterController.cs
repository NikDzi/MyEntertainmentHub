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
    public class CharacterController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CharacterController(MojDbContext context, IWebHostEnvironment environment)
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
            var Character = new AddCharacterVM
            {
                GenderStavke = db.Gender.Select(g => new SelectListItem { Value = g.GenderID.ToString(), Text = g.GenderName }).ToList()
            };

            return View(Character);
        }
        public ActionResult DodajPoruka()
        {
            return View("DodajPoruka");
        }
        [ValidateAntiForgeryToken]
        public ActionResult SnimiForma(AddCharacterVM x)
        {
            //---
            if (!ModelState.IsValid)
            {
                x.GenderStavke = db.Gender.Select(g => new SelectListItem { Value = g.GenderID.ToString(), Text = g.GenderName }).ToList();
                return View("DodajForma", x);
            }
            //---

            Character c;
            if (x.CharacterID == 0)
            {
                c = new Character();
                db.Add(c);
            }
            else
            {
                c = db.Character.Find(x.CharacterID);
            }

            c.FirstName = x.FirstName;
            c.LastName = x.LastName;
            c.Age = x.Age;
            c.DateOfBirth = x.DateOfBirth;
            c.DateOfDeath = x.DateOfDeath;
            c.GenderID = x.GenderID;
            c.Description = x.Description;

            db.SaveChanges();
            TempData["ImeKaraktera"] = x.FirstName + " " + x.LastName; ;
            return Redirect("/Character/DodajPoruka");
        }
        public ActionResult Prikaz()
        {
            List<CharacterVM> Characters = db.Character.Select(c => new CharacterVM
            {
                CharacterID = c.CharacterID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Thumbnail = db.Image.Where(i => i.CharacterID == c.CharacterID && i.Thumbnail == true).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).FirstOrDefault()
            }).ToList();
            return View(Characters);
        }
        public ActionResult PrikazDetaljno(int CharacterID)
        {
            Character c = db.Character.Include(s => s.Gender).SingleOrDefault(s => s.CharacterID == CharacterID);
            if (c == null)
                return RedirectToAction("Prikaz");

            string DoB, DoD;
            if (c.DateOfBirth != null)
            {
                DoB = c.DateOfBirth.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                DoB = "N/A";
            }
            if (c.DateOfDeath != null)
            {
                DoD = c.DateOfDeath.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                DoD = "N/A";
            }

            var model = new CharacterDetailVM
            {
                CharacterID = c.CharacterID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = DoB,
                DateOfDeath = DoD,
                Age = c.Age,
                Description = c.Description,
                Gender = c.Gender.GenderName,
                CastPersonStavke = db.CastPerson.Where(s => s.CharacterID == CharacterID).Select(ch => new CastPersonVM
                {
                    CastPersonID = ch.CastPersonID,
                    CastID = ch.CastID,
                    MediaID = ch.Cast.MediaID,
                    MediaName = ch.Cast.Media.MediaName,
                    PersonID = ch.PersonID,
                    PersonFirstName = ch.Person.FirstName,
                    PersonLastName = ch.Person.LastName
                }).ToList(),
                ImageList = db.Image.Where(i => i.CharacterID == CharacterID).Select(i => new ImageVM
                {
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    CharacterID = i.CharacterID,
                    ImageUniqueFilename = i.ImageUniqueFilename
                }).ToList()
            };

            return View("PrikazDetaljno", model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediForma(int CharacterID)
        {
            Character c = db.Character.Find(CharacterID);
            if (c == null)
                return RedirectToAction("Prikaz");

            var model = new AddCharacterVM
            {
                CharacterID = c.CharacterID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                DateOfDeath = c.DateOfDeath,
                Age = c.Age,
                Description = c.Description,
                GenderID = c.GenderID,
                GenderStavke = db.Gender.Select(g => new SelectListItem { Value = g.GenderID.ToString(), Text = g.GenderName }).ToList()
            };

            return View("DodajForma", model);
        }
        [Authorize(Roles = "Admin")] // treba provjerit je li potrebno!
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int CharacterID)
        {
            List<CastPerson> ZaBrisatiCast = db.CastPerson.Where(s => s.CharacterID == CharacterID).ToList();
            db.RemoveRange(ZaBrisatiCast);

            List<Image> ZaBrisatiSlike = db.Image.Where(s => s.CharacterID == CharacterID).ToList();
            ImageDeleteHelper brisac = new ImageDeleteHelper(db);
            brisac.IzbrisiSlike(ZaBrisatiSlike, hostingEnvironment);

            db.RemoveRange(ZaBrisatiSlike);

            Character c = db.Character.Find(CharacterID);

            TempData["ImeKaraktera"] = c.FirstName + " " + c.LastName;
            db.Remove(c);
            db.SaveChanges();
            return Redirect("/Character/BrisanjePoruka");
        }

        public ActionResult BrisanjePoruka()
        {
            return View();
        }
    }
}