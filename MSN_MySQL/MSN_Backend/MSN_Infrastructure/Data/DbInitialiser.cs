using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSN_Application.Interfaces;
using MSN_Application.Utility;
using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Data
{
    public class DbInitialiser : IDbInitialiser
    {

        private readonly UserManager<MSNUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        ApplicationDbContext _context;

        public DbInitialiser(UserManager<MSNUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

            public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex) { }


            //create roles if not created

            if (!_roleManager.RoleExistsAsync(SD.Role_StandardUser).GetAwaiter().GetResult())
            {

                _roleManager.CreateAsync(new IdentityRole(SD.Role_StandardUser)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();


                //if roles are not created, then add user as well
                _userManager.CreateAsync(new MSNUser
                {
                    firstname = "Admin",
                    lastname = "Admin",
                    age = 30,
                    role = SD.Role_Admin,
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                }, "Admin123*").GetAwaiter().GetResult();


                MSNUser user = _context.MSNUsers.FirstOrDefault(u => u.Email == "admin@admin.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }

            return;
        }
    }
}
