using Microsoft.AspNetCore.Identity;

namespace IdentitySample.CS.Identity.Models.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
