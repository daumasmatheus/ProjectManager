using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Extensions;
using ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration;
using System.Linq;

namespace ProjectManager.Infrastructure.Data.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Priority> Priority { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());            
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());

            #region REMOVE CASCADE DELETE FROM ENTITIES

            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                                               .SelectMany(t => t.GetForeignKeys())
                                               .Where(fk => !fk.IsOwnership &&
                                                            fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion                        

            modelBuilder.Entity<ApplicationUser>(e => e.ToTable(name: "User"));
            modelBuilder.Entity<IdentityRole>(e => e.ToTable(name: "Role"));
            modelBuilder.Entity<IdentityUserRole<string>>(e => e.ToTable(name: "UserRole"));
            modelBuilder.Entity<IdentityUserClaim<string>>(e => e.ToTable(name: "UserClaim"));
            modelBuilder.Entity<IdentityUserLogin<string>>(e => e.ToTable(name: "UserLogin"));
            modelBuilder.Entity<IdentityUserToken<string>>(e => e.ToTable(name: "UserToken"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(e => e.ToTable(name: "RoleClaim"));
        }
    }
}
