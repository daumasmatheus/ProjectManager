using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entities;

namespace ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasMany(t => t.Tasks)
                   .WithOne(p => p.Project);

            builder.HasOne(a => a.Author)
                   .WithMany(p => p.Projects);
                    
        }
    }
}
