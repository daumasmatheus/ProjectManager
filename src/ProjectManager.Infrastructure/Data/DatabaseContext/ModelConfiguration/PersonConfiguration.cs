using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Extensions;

namespace ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasOne(u => u.User)
                   .WithOne(p => p.Person)
                   .HasForeignKey<ApplicationUser>(k => k.PersonId);

            builder.HasMany(t => t.Tasks)
                   .WithOne(p => p.Person);

            builder.HasMany(p => p.Projects)
                   .WithOne(p => p.Author);

            builder.HasMany(c => c.Comments)
                   .WithOne(p => p.Person);
        }
    }    
}
