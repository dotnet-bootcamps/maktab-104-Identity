using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySample.CS.Identity.Controllers
{
    [Authorize]
    public class DriverLicenseController : Controller
    {

        [Authorize(Policy = "CanAskDriverLicense")]
        public IActionResult Request()
        {
            return View();
        }
    }
}
