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
    public class WatchListMediaController : Controller
    {
        private readonly MojDbContext db;
        public WatchListMediaController(MojDbContext context)
        {
            db = context;
        }
        [Authorize(Roles = "Admin,Member")]
        public IActionResult DodajNaListu( int MediaID, string UserID)
        {
            var med = db.Media.Find(MediaID);
            var u = db.Users.Find(UserID);
            var list = new WatchListMedia()
            {
                MediaID = MediaID,
                UserID=UserID,DateAdded=DateTime.Now,
                Watchstatus="interested"
            
            };

            db.Add(list);
            db.SaveChanges();
            return RedirectToAction("Prikaz","Media");
        }
        [Authorize(Roles = "Admin,Member")]

        public IActionResult Ukloni(int MediaID, string UserID)
        {
            var med = db.WatchListMedia.Where(i =>i.UserID == UserID).FirstOrDefault(i => i.MediaID==MediaID);
            db.Remove(med);
            db.SaveChanges();
            return RedirectToAction("Prikaz", "Media");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
