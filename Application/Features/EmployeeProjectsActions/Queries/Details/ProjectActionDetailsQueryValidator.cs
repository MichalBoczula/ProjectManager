using Application.Contracts.Persistance;
using Application.Features.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Queries.Details
{
    public static class ProjectActionDetailsQueryValidator
    {
        public static async Task<List<Exception>> ValidateAsync(
           ProjectActionDetailsQuery request,
           IProjectManagerDbContext _context,
           CancellationToken cancellationToken)
        {
            var list = new List<Exception>();

            if (!Guid.TryParse(request.ProjectActionId, out Guid guid))
            {
                list.Add(new ProjectActionInvalidGuidException());
            }
            else
            {
                var projectAction = await (from pa in _context.ProjectActions
                                           where pa.Id == guid
                                           select pa)
                                        .FirstOrDefaultAsync(cancellationToken);

                if(projectAction == null)
                {
                    list.Add(new ProjectActionDoesntExistsException());
                }
            }

            var employeeId = await (from e in _context.Employees
                                    where e.Email == request.Email
                                    select e.Id)
                                    .FirstOrDefaultAsync(cancellationToken);

            if (employeeId == Guid.Empty)
            {
                list.Add(new EmployeeDoesntExistsException());
            }

            return list;
        }
    }
}
