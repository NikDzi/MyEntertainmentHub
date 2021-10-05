using ClassLibrary1.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class AddRoleHelper
    {
        private static MojDbContext db;
        public AddRoleHelper(MojDbContext context)
        {
            db = context;
        }
        private readonly UserManager<AppUser> _userManager;
        public static void Dodaj(AppUser user)
        {
            var rl = db.UserRoles.FirstOrDefault(i => i.UserId == user.Id);

            rl = new IdentityUserRole<string>();
            rl.UserId = user.Id;
            var def = db.Roles.Where(i => i.Name == "Member").FirstOrDefault();
            rl.RoleId = def.Id;
            db.Add(rl);
            db.SaveChanges();

        }
    }
}
