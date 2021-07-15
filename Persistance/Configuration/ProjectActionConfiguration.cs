using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration
{
    public class ProjectActionConfiguration : IEntityTypeConfiguration<ProjectAction>
    {
        public void Configure(EntityTypeBuilder<ProjectAction> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(pa => pa.Manager)
                .WithMany(m => m.ProjectActions)
                .HasForeignKey(pa => pa.ManagerId);
            builder.HasOne(pa => pa.Employee)
                .WithMany(e => e.ProjectActions)
                .HasForeignKey(pa => pa.EmployeeId);
            builder.HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectActions)
                .HasForeignKey(pa => pa.ProjectId);
        }
    }
}
