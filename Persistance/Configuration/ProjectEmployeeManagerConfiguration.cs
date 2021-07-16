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
    public class ProjectEmployeeManagerConfiguration : IEntityTypeConfiguration<ProjectEmployeeManager>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployeeManager> builder)
        {
            builder.HasKey(k => new { k.EmployeeId, k.ProjectId, k.ManagerId });
            builder.HasOne(pem => pem.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(pem => pem.EmployeeId);
            builder.HasOne(pem => pem.Project)
                .WithMany(p => p.Projects)
                .HasForeignKey(pem => pem.ProjectId);
            builder.HasOne(pem => pem.Manager)
               .WithMany(m => m.Projects)
               .HasForeignKey(pem => pem.ManagerId);
        }
    }
}
