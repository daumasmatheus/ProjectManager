using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Extensions;

namespace ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");            

            builder.HasOne(p => p.Status)
                   .WithMany()
                   .HasForeignKey("StatusId")
                   .IsRequired();

            builder.HasOne(p => p.Priority)
                   .WithMany()
                   .HasForeignKey("PriorityId")
                   .IsRequired();

            builder.HasOne(p => p.Person)
                   .WithMany(t => t.Tasks);
                   //.IsRequired();

            builder.HasMany(c => c.Comments)
                   .WithOne(t => t.Task);            
        }
    }    
}
