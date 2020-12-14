using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entities;

namespace ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasOne(p => p.Person)
                   .WithMany(c => c.Comments);

            builder.HasOne(t => t.Task)
                   .WithMany(c => c.Comments);
        }
    }
}
