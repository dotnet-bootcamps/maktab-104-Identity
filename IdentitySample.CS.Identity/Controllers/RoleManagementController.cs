using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.CS.Identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleManagementController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleManagementController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _roleManager.Roles.ToListAsync();
            return View(model);
        }
    }
}
