using OnSearch.Web.Entities;
using OnSearch.Web.Enums;
using OnSearch.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly UserHelper _userHelper;

        public SeedDb(DataContext context, UserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Mateo", "Vergara", "mateovergara10@outlook.com", "322 311 4620", UserType.Admin);
            await CheckUserAsync("1010", "Mateo", "Vergara", "mateovergara11@outlook.com", "322 311 4620", UserType.User);
            await CheckUserAsync("1010", "Mateo", "Vergara", "mateovergara12@outlook.com", "322 311 4620", UserType.User);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.UserS.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }
    }
}
