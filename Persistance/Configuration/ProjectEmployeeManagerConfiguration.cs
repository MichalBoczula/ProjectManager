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
            builder.HasOne(pe => pe.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(pe => pe.EmployeeId);
            builder.HasOne(pe => pe.Project)
                .WithMany(p => p.Projects)
                .HasForeignKey(pe => pe.ProjectId);
            builder.HasOne(pe => pe.Project)
               .WithMany(m => m.Projects)
               .HasForeignKey(pe => pe.ManagerId);
        }
    }
}
