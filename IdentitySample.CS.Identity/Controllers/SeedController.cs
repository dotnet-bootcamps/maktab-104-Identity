using IdentitySample.CS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySample.CS.Identity.Controllers
{
    public class SeedController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public SeedController(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Index()
        {
            try
            {
                await _roleManager.CreateAsync(new AppRole(){Name = AppRoles.Admin.ToString() });
                await _roleManager.CreateAsync(new AppRole(){Name = AppRoles.Expert.ToString() });
                await _roleManager.CreateAsync(new AppRole(){Name = AppRoles.Customer.ToString() });


                var newUser = new AppUser()
                {
                    UserName = "admin@example.com",
                    FirstName = "mahmoud",
                    LastName = "sav",
                    NationalCode = "1234567890",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    PhoneNumber = "09350000000",
                    PhoneNumberConfirmed = true,
                };
                await _userManager.CreateAsync(newUser, "Aa@1234567");


                var adminUser = await _userManager.FindByEmailAsync("admin@example.com");
                if (adminUser != null)
                {
                    await _userManager.AddToRoleAsync(adminUser, AppRoles.Admin.ToString());
                }

                return "Everything is Ok";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
