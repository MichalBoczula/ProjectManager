using Application.Contracts.Persistance;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ForTraning
{
    public class RepositoryForTesting : IRepositoryForTesting
    {
        private readonly IProjectManagerDbContext _context;

        public IQueryable<Employee> GetEmps()
        {

            return (from e in _context.Employees
                    select e).AsQueryable();

        }
    }
}
