using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using WebApplication1.ViewModels;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Hubs;


namespace WebApplication1.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MojDbContext db;
        private IHubContext<MyHub> _hubContext;
        public CommentsController(MojDbContext context, IHubContext<MyHub> hubContext)
        {
            db = context;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Member")]

        public async Task<IActionResult>   AddComment(AddCommentVM cm)
        {
            Comments dbcm = new Comments();
            dbcm.MediaID = cm.MediaID;
            dbcm.Media = db.Media.Find(cm.MediaID);
            dbcm.UserID = cm.UserID;
            dbcm.User = db.Users.Find(cm.UserID);
            dbcm.DateOfCreation = DateTime.Now;
            dbcm.CommentContent = cm.CommentContent;
            dbcm.Score = 0;
            dbcm.Reports = 0;
            dbcm.RUID = new List<CommentReports>();
            db.Add(dbcm);
            db.SaveChanges();
            //CommentReports rp = new CommentReports();
            //rp.CommentID = dbcm.CommentID;
            //rp.UserID = dbcm.UserID;
            //dbcm.RUID.Add(rp);
            AddCommentVM cmnt = new AddCommentVM()
            {
                CommentContent = dbcm.CommentContent,
                CommentID = dbcm.CommentID,
                DateOfCreation = dbcm.DateOfCreation,
                MediaID = dbcm.MediaID,
                Reports = 0,
                RUIDS = null,
                UserID = dbcm.UserID,
                User = dbcm.User,

            };
            await _hubContext.Clients.All.SendAsync("recievemessage", cmnt);

            

            return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = cm.MediaID });
        }
        //[HttpPost]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Report(int CommentID, string? UserID)
        {
            var cm = db.Comments.Find(CommentID);
            cm.Reports++;
            //cm.RUID = UserID;
            db.SaveChanges();
            return RedirectToAction("Add", "CommentReports", new { CommentID = cm.CommentID , UserID= UserID});
            //return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = cm.MediaID });

        }
        [Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete (int CommentID)
        {
            //ne treba ova akcija uopce moze se odma redirectat na /CommentReports/Remove.
            var cm = db.Comments.Find(CommentID);
            var commentID = cm.CommentID;
            var user = cm.UserID;
            var media = cm.MediaID;
            //db.Remove(cm);
            //db.SaveChanges();
            return RedirectToAction("Remove", "CommentReports", new { CommentID = commentID, UserID = user , MediaID = media});
        }
    }
}
