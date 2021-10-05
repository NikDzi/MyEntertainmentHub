using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using ClassLibrary1.Model;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        private readonly MojDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ImageController(MojDbContext context, IWebHostEnvironment environment)
        {
            db = context;
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(int LocationID, int PersonID, int MediaID, int CompanyID, int CharacterID)
        {
            var Image = new ImageVM()
            {
                LocationID = LocationID,
                PersonID = PersonID,
                MediaID = MediaID,
                CompanyID = CompanyID,
                CharacterID = CharacterID
            };

            if (LocationID != 0)
            {
                if (db.Image.Where(i => i.LocationID == LocationID).Any(t => t.Thumbnail == true))
                {
                    Image.Thumbnail = true;
                }
            }
            if (CompanyID != 0)
            {
                if (db.Image.Where(i => i.CompanyID == CompanyID).Any(t => t.Thumbnail == true))
                {
                    Image.Thumbnail = true;
                }
            }
            if (MediaID != 0)
            {
                if (db.Image.Where(i => i.MediaID == MediaID).Any(t => t.Thumbnail == true))
                {
                    Image.Thumbnail = true;
                }
            }
            if (PersonID != 0)
            {
                if (db.Image.Where(i => i.PersonID == PersonID).Any(t => t.Thumbnail == true))
                {
                    Image.Thumbnail = true;
                }
            }
            if (CharacterID != 0)
            {
                if (db.Image.Where(i => i.CharacterID == CharacterID).Any(t => t.Thumbnail == true))
                {
                    Image.Thumbnail = true;
                }
            }

            return View(Image);
        }
        //[HttpPost]
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Selectpfp(string UserID)
        {
            var Image = new ImageVM()
            {
               UserID=UserID
            };
            return View("Addpfp",Image);
        }
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Changepfp(string UserID)
        {
            var postojeca = db.Image.FirstOrDefault(i => i.UserID == UserID);
            if (postojeca!=null)
            {
                db.Remove(postojeca);
                db.SaveChanges();
                //brisanje slike iz foldera
                string filePath = hostingEnvironment.WebRootPath + "\\uploads\\" + postojeca.ImageUniqueFilename;

                if (System.IO.File.Exists(filePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(filePath);
                }
            }
           
            return RedirectToAction("Selectpfp","Image", new { UserID = UserID });
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Addpfp(ImageVM model)
        {
           
            var image = new Image()
            {
                UserID = model.UserID,
                ImageUniqueFilename = GetUniqueFileName(model.MyImage.FileName)
            };
            if (model.MyImage != null)
            {
                var uniqueFileName = image.ImageUniqueFilename;
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            db.Image.Add(image);
            db.SaveChanges();
            return RedirectToAction("ViewProfile", "User", new { UserID = model.UserID });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ImageVM model)
        {

            var Image = new Image()
            {
                ImageCaption = model.ImageCaption,
                ImageDescription = model.ImageDescription,
                ImageUniqueFilename = GetUniqueFileName(model.MyImage.FileName)
            };

            if (model.Thumbnail == false)
            {
                Image.Thumbnail = false;
            }
            else
            {
                //Image.Thumbnail = Convert.ToBoolean(model.Thumbnail);
                Image.Thumbnail = true;
            }

            if (model.LocationID != 0) { Image.LocationID = model.LocationID; }
            if (model.CompanyID != 0) { Image.CompanyID = model.CompanyID; }
            if (model.MediaID != 0) { Image.MediaID = model.MediaID; }
            if (model.PersonID != 0) { Image.PersonID = model.PersonID; }
            if (model.CharacterID != 0) { Image.CharacterID = model.CharacterID; }

            if (model.MyImage != null)
            {
                var uniqueFileName = Image.ImageUniqueFilename;
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            db.Image.Add(Image);
            db.SaveChanges();
            //return RedirectToAction("Index", "Home");
            if (model.LocationID != 0)
            {
                return RedirectToAction("PrikazDetaljno", "Location", new { LocationID = model.LocationID });
            }
            else if (model.CompanyID != 0)
            {
                return RedirectToAction("PrikazDetaljno", "Company", new { CompanyID = model.CompanyID });
            }
            else if (model.MediaID != 0)
            {
                return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = model.MediaID });
            }
            else if (model.PersonID != 0)
            {
                return RedirectToAction("PrikazDetaljno", "Person", new { PersonID = model.PersonID });
            }
            else if (model.CharacterID != 0)
            {
                return RedirectToAction("PrikazDetaljno", "Character", new { CharacterID = model.CharacterID });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult PrikazZaBrisanje(int? LocationID, int? PersonID, int? MediaID, int? CompanyID, int? CharacterID)
        {
            //pohranit listu ImageVM-ova za prosljedjeni id
            //treba se vratiti na ovaj dio i skontat nacin da se eliminise ponavljanje koda!
            List<ImageVM> ImageList = new List<ImageVM>();
            if (LocationID != null)
            {
                ImageList = db.Image.Where(i => i.LocationID == LocationID).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename,
                    Thumbnail = i.Thumbnail,
                    LocationID = i.LocationID
                }).ToList();
            }
            if (CompanyID != null)
            {
                ImageList = db.Image.Where(i => i.CompanyID == CompanyID).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename,
                    Thumbnail = i.Thumbnail,
                    CompanyID = i.CompanyID
                }).ToList();
            }
            if (MediaID != null)
            {
                ImageList = db.Image.Where(i => i.MediaID == MediaID).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename,
                    Thumbnail = i.Thumbnail,
                    MediaID = i.MediaID
                }).ToList();
            }
            if (PersonID != null)
            {
                ImageList = db.Image.Where(i => i.PersonID == PersonID).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename,
                    Thumbnail = i.Thumbnail,
                    PersonID = i.PersonID
                }).ToList();
            }
            if (CharacterID != null)
            {
                ImageList = db.Image.Where(i => i.CharacterID == CharacterID).Select(i => new ImageVM
                {
                    ImageID = i.ImageID,
                    ImageCaption = i.ImageCaption,
                    ImageDescription = i.ImageDescription,
                    ImageUniqueFilename = i.ImageUniqueFilename,
                    Thumbnail = i.Thumbnail,
                    CharacterID = i.CharacterID
                }).ToList();
            }

            //proslijedit u view
            return View(ImageList);
        }
        [Authorize(Roles = "Admin")] // treba provjerit je li potrebno!
        [ValidateAntiForgeryToken]
        public ActionResult Brisanje(int ImageID)
        {
            var img = db.Image.Find(ImageID);
            int? locID, comID, medID, perID, chaID;
            if (img.LocationID != null) { locID = img.LocationID; }
            else { locID = null; }
            if (img.CompanyID != null) { comID = img.CompanyID; }
            else { comID = null; }
            if (img.MediaID != null) { medID = img.MediaID; }
            else { medID = null; }
            if (img.PersonID != null) { perID = img.PersonID; }
            else { perID = null; }
            if (img.CharacterID != null) { chaID = img.CharacterID; }
            else { chaID = null; }

            Image i = db.Image.Find(ImageID);

            //brisanje slike iz foldera
            string filePath = hostingEnvironment.WebRootPath + "\\uploads\\" + i.ImageUniqueFilename;

            if (System.IO.File.Exists(filePath))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete(filePath);
            }
            //brisanje podataka o slici iz baze
            db.Remove(i);
            db.SaveChanges();
            if (locID != null)
            {
                return RedirectToAction("PrikazDetaljno", "Location", new { LocationID = locID });
            }
            else if (comID != null)
            {
                return RedirectToAction("PrikazDetaljno", "Company", new { CompanyID = comID });
            }
            else if (medID != null)
            {
                return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = medID });
            }
            else if (perID != null)
            {
                return RedirectToAction("PrikazDetaljno", "Person", new { PersonID = perID });
            }
            else if (chaID != null)
            {
                return RedirectToAction("PrikazDetaljno", "Character", new { CharacterID = chaID });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}