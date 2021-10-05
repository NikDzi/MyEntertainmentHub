using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TempForReports;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class AdminController : Controller
    {
        private readonly MojDbContext db;
        private readonly IEmailSender _emailSender;
        public AdminController(MojDbContext context, IEmailSender emailSender)
        {
            db = context;
            _emailSender = emailSender;
        }

        public IActionResult GetUsers(string q,int currentpage=1,int itemsperpage=10)
        {
            var queryable = db.Users.Where(s => (q == null || s.UserName.StartsWith(q)) && s.LockoutEnd==null );
            //lockoutend provjera je jeli user bannan, ako je banan ne pulla se
            var broj = db.Users.Where(s => (q == null || s.UserName.StartsWith(q)) && s.LockoutEnd == null).Count();
       
            var model = new angularprofileVM();
            model.Broj = broj;
            model.users = queryable.Skip((currentpage - 1) * itemsperpage)
                .Take(itemsperpage)
                .Select(s => new angularprofileVM.row()
                {
                    userID = s.Id,
                    username = s.UserName,
                    total=db.Bans.Count(p=>p.UserID == s.Id)
                    
                }).ToList();
            
            return Ok(model);
        }

        public IActionResult Unban(string q)
        {
            var user = db.Users.Find(q);
            user.LockoutEnd = null;
            user.LockoutEnabled = false;
            db.SaveChanges();
            return Ok();
        }

        public IActionResult Getbanned(string q, int currentpage = 1, int itemsperpage = 10)
        {
            var queryable = db.Users.Where(s => (q == null || s.UserName.StartsWith(q)) && s.LockoutEnd != null && s.LockoutEnabled == true);
            //lockoutend provjera je jeli user bannan
            var broj = db.Users.Where(s => (q == null || s.UserName.StartsWith(q)) && s.LockoutEnd != null && s.LockoutEnabled==true).Count();

            var model = new angularprofileVM();
            model.Broj = broj;
            model.users = queryable.Skip((currentpage - 1) * itemsperpage)
                .Take(itemsperpage)
                .Select(s => new angularprofileVM.row()
                {
                    userID = s.Id,
                    username = s.UserName,
                    total = db.Bans.Count(p => p.UserID == s.Id)

                }).ToList();

            return Ok(model);
        }
        
        public async Task<IActionResult> BanUser(string banid,string days,string reason)
        {
            var test = DateTimeOffset.Now;
            var target = db.Users.Find(banid);
            target.LockoutEnd = test.AddDays(int.Parse(days));
            target.LockoutEnabled = true;
            var ban = new Bans();
            ban.UserID = target.Id;
            ban.Reason = reason;
            ban.UserName = target.UserName;
            ban.Duration = int.Parse(days);
            db.Add(ban);
            db.SaveChanges();
            var ran = DateTimeOffset.Now;
            var sec = target.LockoutEnd - ran;
            using (MailMessage mail = new MailMessage())
            {
                try
                {
                    mail.From = new MailAddress("p1752.rs1seminarski@gmail.com");
                    mail.To.Add(target.Email);
                    mail.Subject = "Account suspended from MEH";
                    mail.Body = "Your account has been banned from MEH for " + ban.Duration +
                                " for the following reason(s) " + ban.Reason + ".";
                    mail.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("p1752.rs1seminarski@gmail.com", "P1752rs1seminarski");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                    }
                }
                catch (Exception ex)
                {
                    
                }
                
            }

            return Ok(sec);
        }
        public IActionResult Index()
        {
            return View();
        }

        public void  SeedUsers()
        {
            for (int i = 5; i < 50; i++)
            {
                AppUser u;
                u= new AppUser();
                db.Add(u);

                u.UserName = "user" + i;
                u.NormalizedUserName = "USER" + i;
                u.Email = "xxxx@example.com";
                u.NormalizedEmail = "XXXX@EXAMPLE.COM";
                u.PhoneNumber = "+111111111111";
                u.EmailConfirmed = true;
                u.SecurityStamp = Guid.NewGuid().ToString("D");
                
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(u, "Test123!");
                u.PasswordHash = hashed;

              
                

            }

            db.SaveChanges();
        }

        public void Fillbans()
        {
            var test = DateTimeOffset.Now;
            var vrijeme = test.AddDays(5);
            var ids = db.Bans.Select(s => s.UserID).ToList();
            foreach (var s in ids)
            {
                var user = db.Users.Find(s);
                
                    user.LockoutEnabled = true;
                    user.LockoutEnd = vrijeme;
                
            }

            db.SaveChanges();
        }

        public void SeedBans()
        {
            var test = DateTimeOffset.Now;
            for (int i = 100; i < 50; i++)
            {
                AppUser u;
                u = new AppUser();
                db.Add(u);

                u.UserName = "user" + i;
                u.NormalizedUserName = "USER" + i;
                u.Email = "xxxx@example.com";
                u.NormalizedEmail = "XXXX@EXAMPLE.COM";
                u.PhoneNumber = "+111111111111";
                u.EmailConfirmed = true;
                u.SecurityStamp = Guid.NewGuid().ToString("D");
                u.LockoutEnd = test.AddDays(5);
                u.LockoutEnabled = true;
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(u, "Test123!");
                u.PasswordHash = hashed;


                var ban = new Bans();
                ban.UserID = u.Id;
                ban.Reason = "Seeded Banned user";
                ban.UserName = u.UserName;
                ban.Duration = 5;
                db.Add(ban);

            }

            db.SaveChanges();
        }
        
        public IActionResult GetReport()
        {
            List<Report> podaci = db.Bans.Select(s => new Report
            {
                Duration = s.Duration,
                Reason = s.Reason,
                UserName = s.UserName,
            }).ToList();
            LocalReport report = new LocalReport("Reports/Report1.rdlc");
            report.AddDataSource("DataSet1",podaci);
            ReportResult result = report.Execute(RenderType.Pdf);
            return File(result.MainStream,"application/pdf");
        }
    }
}