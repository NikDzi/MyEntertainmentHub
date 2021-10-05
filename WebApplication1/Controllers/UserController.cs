using ClassLibrary1.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModels;
using WebApplication1.Areas;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Helpers;
namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly MojDbContext db;
        public UserController(MojDbContext context)
        {
            db = context;
        }
        public IActionResult ViewProfile(string UserID)
        {
            var user = db.Users.Find(UserID);
            var rl = db.UserRoles.FirstOrDefault(i=>i.UserId==UserID);
            // dodjeljuje default role useru koji je tek registriran
            if (rl == null)
            {
                rl = new IdentityUserRole<string>();
                rl.UserId = UserID;
                var def = db.Roles.Where(i => i.Name == "Member").FirstOrDefault();
                rl.RoleId = def.Id;
                db.Add(rl);
                db.SaveChanges();
            }  
            var rolename = db.Roles.Find(rl.RoleId);

            var x = db.WatchListMedia.Where(i => i.UserID == UserID).Select(i => i.MediaID).ToList();
            var model = new UserProfileVM
            {
                UserID = user.Id,
                Username = user.UserName,
                ProfilePicture=db.Image.FirstOrDefault(i=>i.UserID==UserID),
                Role=rolename.Name,
                Rating=0,
                Comments = db.Comments.Where(i => i.UserID == UserID).Select(i => new Comments
                {
                   CommentID=i.CommentID,
                   User=i.User,
                   UserID=i.UserID,
                   CommentContent=i.CommentContent,
                   DateOfCreation=i.DateOfCreation,
                   Score=i.Score,
                   Media=i.Media,
                   MediaID=i.MediaID,
                   Reports=i.Reports,
                   RUID=i.RUID

                }).ToList()
                
            };
            model.WatchListedMedia = new List<Media>();
            foreach (var t in x)
            {
                if (t!=null)
                {
                    model.WatchListedMedia.Add(db.Media.Find(t));

                }
            }
            if (model.WatchListedMedia != null)
            {
                model.Rating = model.Comments.Count() + model.WatchListedMedia.Count();

            }

            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
