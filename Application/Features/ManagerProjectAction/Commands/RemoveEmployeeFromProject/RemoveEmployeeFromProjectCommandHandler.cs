using Application.Contracts.Persistance;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommandHandler : IRequestHandler<RemoveEmployeeFromProjectCommand, ProjectEmployeeManager>
    {
        private readonly IProjectManagerDbContext _context;

        public RemoveEmployeeFromProjectCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEmployeeManager> Handle(RemoveEmployeeFromProjectCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);

            if (managerId == Guid.Empty)
            {
                return null;
            }

            if (!Guid.TryParse(request.ProjectId, out Guid projId))
            {
                return null;
            }

            var projectId = await (from p in _context.Projects
                                   where p.Id == projId
                                   select p.Id).FirstOrDefaultAsync(cancellationToken);

            if (projectId == Guid.Empty)
            {
                return null;
            }

            if (!Guid.TryParse(request.EmployeeId, out Guid empId))
            {
                return null;
            }

            var employeeId = await (from e in _context.Employees
                                    where e.Id == empId
                                    select e.Id).FirstOrDefaultAsync(cancellationToken);

            if (employeeId == Guid.Empty)
            {
                return null;
            }

            var actions = await (from pa in _context.ProjectActions
                                 where pa.EmployeeId == empId
                                    && pa.ManagerId == managerId
                                    && pa.ProjectId == projId
                                 select pa).ToListAsync(cancellationToken);

            if (actions.Count() == 0)
            {
                return null;
            }

            foreach (var ele in actions)
            {
                ele.EmployeeId = Guid.Empty;

                _context.ProjectActions.Update(ele);
                await _context.SaveChangesAsync(cancellationToken);
            }

            var item = await (from pem in _context.ProjectEmployeeManagers
                              where pem.EmployeeId == empId
                                && pem.ManagerId == managerId
                                && pem.ProjectId == projectId
                              select pem).FirstOrDefaultAsync(cancellationToken);

            _context.ProjectEmployeeManagers.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }
}
