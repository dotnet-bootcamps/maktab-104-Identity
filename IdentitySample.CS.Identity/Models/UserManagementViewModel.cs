namespace IdentitySample.CS.Identity.Models;

public class UserManagementViewModel : AppUser
{
    public IEnumerable<string> Roles { get; set; }
}