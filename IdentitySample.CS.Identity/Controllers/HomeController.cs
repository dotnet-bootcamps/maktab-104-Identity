using IdentitySample.CS.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IdentitySample.CS.Identity.Infrastructures;
using Microsoft.AspNetCore.Authorization;

namespace IdentitySample.CS.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.GetUserId<int>();
                /*
                 * var expertProfile = appdbcontext.experts.where(w=>w.userId=userId).firstOrDefault();
                 * if(expertProfile is null)
                 * {
                 * }
                 * else
                 * {                 
                 * }
                 */
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Authorize(Roles = "Admin,Customer")]
        public string SensitiveData()
        {
            return "Test Authorization";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
