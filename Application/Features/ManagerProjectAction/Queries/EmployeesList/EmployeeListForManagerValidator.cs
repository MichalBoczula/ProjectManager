using Application.Contracts.Persistance;
using Application.Features.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.EmployeesList
{
    public static class EmployeeListForManagerValidator
    {
        public static async Task<List<Exception>> ValidateAsync(
            EmployeeListFormManagerQuery request,
            IProjectManagerDbContext _context,
            CancellationToken cancellationToken)
        {
            var list = new List<Exception>();
            var manager = from m in _context.Managers
                          where request.Email == m.Email
                          select m.Id;

            if (await manager.FirstOrDefaultAsync(cancellationToken) == Guid.Empty)
            {
                list.Add(new ManagerDoesntExistsException());
            }

            return list;
        }
    }
}
