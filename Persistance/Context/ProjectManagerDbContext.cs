using Application.Contracts.Persistance;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Seed;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class ProjectManagerDbContext : DbContext, IProjectManagerDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAction> ProjectActions { get; set; }
        public DbSet<ProjectEmployeeManager> ProjectEmployeeManagers { get; set; }

        public ProjectManagerDbContext([NotNull] DbContextOptions<ProjectManagerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "";
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = "";
                        entry.Entity.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = "";
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
                        entry.Entity.InactivatedBy = "";
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
