using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Authentication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(e => e.ToTable(name: "User"));
            builder.Entity<IdentityRole>(e => e.ToTable(name: "Role"));
            builder.Entity<IdentityUserRole<string>>(e => e.ToTable(name: "UserRole"));
            builder.Entity<IdentityUserClaim<string>>(e => e.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(e => e.ToTable(name: "UserLogin"));
            builder.Entity<IdentityUserToken<string>>(e => e.ToTable(name: "UserToken"));
            builder.Entity<IdentityRoleClaim<string>>(e => e.ToTable(name: "RoleClaim"));
        }
    }
}
