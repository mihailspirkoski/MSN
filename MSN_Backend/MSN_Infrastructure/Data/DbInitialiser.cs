using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSN_Application.Interfaces;
using MSN_Application.Services.Interface;
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

        private readonly IUserService _userService;

        public DbInitialiser(IUserService userService)
        {
            _userService = userService;
        }

        public async void Initialize()
        {
            
            List<MSNUser> allusers = await _userService.GetAllUsers();
            if(allusers.Count == 0)
            {
                MSNUser user = new MSNUser();
                user.email = "admin@admin.com";
                user.password = BCrypt.Net.BCrypt.HashPassword("Admin123*");
                user.firstname = "Admin";
                user.lastname = "Admin";
                user.age = 30;
                user.role = SD.Role_Admin;
                await _userService.CreateUser(user);
            }
            return;

        }
    }
}
