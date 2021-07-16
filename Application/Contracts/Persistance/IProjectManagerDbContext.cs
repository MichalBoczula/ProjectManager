using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IProjectManagerDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectAction> ProjectActions { get; set; }
        DbSet<ProjectEmployeeManager> ProjectEmployeeManagers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
