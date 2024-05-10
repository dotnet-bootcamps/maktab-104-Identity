using IdentitySample.CS.Identity.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.CS.Identity.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.HasDefaultSchema("Identity");

            builder.Entity<AppRole>(e => e.ToTable("Roles", "Identity"));
            builder.Entity<IdentityRoleClaim<int>>(e => e.ToTable("RoleClaims", "Identity"));
            
            builder.Entity<AppUser>(e => e.ToTable("Users", "Identity"));
            builder.Entity<IdentityUserClaim<int>>(e => e.ToTable("UserClaims", "Identity"));
            builder.Entity<IdentityUserLogin<int>>(e => e.ToTable("UserLogins", "Identity"));
            builder.Entity<IdentityUserRole<int>>(e => e.ToTable("UserRoles", "Identity"));
            builder.Entity<IdentityUserToken<int>>(e => e.ToTable("UserTokens", "Identity"));
        }
    }
}
