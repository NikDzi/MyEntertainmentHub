using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.ViewModels;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers
{
    [Authorize]
    public class MistakeController : Controller
    {
        private readonly MojDbContext db;
        public MistakeController(MojDbContext context)
        {
            db = context;
        }
        
        public ActionResult DodajForma(int mediaid)
        {
            var media = db.Media.Find(mediaid);
            var model = new AddMistakeVM

            {
                MistakeTicketMediaType = db.Media.Select(v => new SelectListItem { Value = v.MediaID.ToString(), Text = v.MediaName }).ToList(),
                MistakeTicketTypeStavke = db.MistakeTicketType.Select(m => new SelectListItem { Value = m.MistakeTicketTypeID.ToString(), Text = m.TypeName }).ToList(),
                MediaID = mediaid,
                Media = media,
                
            };

            return PartialView(model);
        }
        public ActionResult DodajPoruka()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Member")]
        public ActionResult SnimiForma(AddMistakeVM x)
        {

            MistakeTickets M = new MistakeTickets();
            M.MistakeTicketTypeID = x.MistakeTicketTypeID;
            M.DateOfCreation = DateTime.Now;
            M.Description = x.Description;
            M.MediaID = x.Media.MediaID;
            M.UserID = x.UserID;
            //Identitytestvalue se ne koristi u originalnu namjenu nego u prikazivanje lokacije greske u reportu
            M.IdentityTestValue = db.MistakeTicketType.Where(s => s.MistakeTicketTypeID == x.MistakeTicketTypeID).Select(s => s.TypeName).FirstOrDefault();

            db.Add(M);
            db.SaveChanges();
            var desc = db.Media.Where(s => s.MediaID == M.MediaID).FirstOrDefault();
            //List < PersonOccupation > ListaPostojecihPO = db.PersonOccupation.Where(s => s.PersonID == p.PersonID).ToList();
            //Person p = db.Person.Include(s => s.City).Include(s => s.City.Country).SingleOrDefault(s => s.PersonID == PersonID);
            string name = desc.MediaName;
            @TempData["medianame"] = name;
            return View("DodajPoruka");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<AddMistakeVM> mistakes = db.MistakeTickets.Select(s => new AddMistakeVM
            {
                MistakeTicketID = s.MistakeTicketID,
                User = db.Users.SingleOrDefault(u => u.Id == s.UserID),
                UserID = s.UserID,
                Description = s.Description,
                DateOfCreation = s.DateOfCreation,
                Media = db.Media.FirstOrDefault(u => u.MediaID == s.MediaID),
                MediaID = db.Media.FirstOrDefault(u => u.MediaID == s.MediaID).MediaID,
                MistakeTicketTypeID = s.MistakeTicketTypeID,
                Identitytestvalue=s.IdentityTestValue
            }).ToList();
      
            return View(mistakes);
  
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int MistakeTicketID)
        {
            MistakeTickets m = db.MistakeTickets.Find(MistakeTicketID);
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/Media/BrisanjePoruka");
        }
    }
}
