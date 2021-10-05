using ClassLibrary1.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CommentReportsController : Controller
    {
        private readonly MojDbContext db;
        public CommentReportsController(MojDbContext context)
        {
            db = context;
        }
        [Authorize(Roles = "Admin,Member")]

        public IActionResult Index()
        {
            List<AddCommentVM> cms = db.Comments.Select(s => new AddCommentVM
            {
                CommentID = s.CommentID,
                CommentContent = s.CommentContent,
                DateOfCreation=s.DateOfCreation,
                Media=db.Media.FirstOrDefault(u=>u.MediaID == s.MediaID),
                MediaID= s.MediaID,
                Reports=s.Reports,
                Score=s.Score,
                User = db.Users.FirstOrDefault(u=>u.Id == s.UserID),
                UserID = s.UserID,
                RUIDS=s.RUID
                
            }).ToList();
            
            List<AddCommentVM> rs = new List<AddCommentVM>();
            foreach (var x in cms)
            {
                if (x.Reports > 0)
                {
                    rs.Add(x);
                }
            }

            
            return View(rs);
        }
        [Authorize(Roles = "Admin,Member")]

        public IActionResult Add(int CommentID,string? UserID)
        {
            var cm = db.Comments.Find(CommentID);
            cm.RUID = new List<CommentReports>();
            CommentReports r = new CommentReports();
            r.CommentID = cm.CommentID;
            r.UserID = UserID;
            r.Comment = cm;
            cm.RUID.Add(r);
            db.Add(r);
            db.SaveChanges();
            
            return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = cm.MediaID });
        }
        [Authorize(Roles = "Admin,Member")]

        public IActionResult Remove(int CommentID, string? UserID, int MediaID)
        {
            var r = db.Comments.Where(i => i.CommentID == CommentID && i.UserID == UserID).FirstOrDefault();
            int? temp = MediaID;
            var cm = db.Comments.Find(CommentID);
            db.Remove(r);
            db.Remove(cm);
            db.SaveChanges();

            return RedirectToAction("PrikazDetaljno", "Media", new { MediaID = temp });
        }
    }
}
