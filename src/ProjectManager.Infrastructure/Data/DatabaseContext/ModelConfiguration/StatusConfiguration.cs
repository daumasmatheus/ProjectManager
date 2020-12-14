using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Entities.Enums;
using System;
using System.Linq;

namespace ProjectManager.Infrastructure.Data.DatabaseContext.ModelConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                Enum.GetValues(typeof(EStatus))
                    .Cast<EStatus>()
                    .Select(e => new Status()
                    {
                        StatusId = (int)e,
                        Name = e.ToString()
                    })
            );
        }
    }
}
