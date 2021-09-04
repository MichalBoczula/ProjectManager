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

            var project = await (from pem in _context.ProjectEmployeeManagers
                                 where pem.EmployeeId == request.EmployeeId
                                     && pem.ManagerId == managerId
                                     && pem.ProjectId == request.ProjectId
                                 select pem).FirstOrDefaultAsync(cancellationToken);

            if (project == null)
            {
                return null;
            }
            else
            {
                var actions = await (from pa in _context.ProjectActions
                                     where pa.EmployeeId == request.EmployeeId
                                        && pa.ManagerId == managerId
                                        && pa.ProjectId == request.ProjectId
                                     select pa).ToListAsync(cancellationToken);

                foreach (var ele in actions)
                {
                    ele.EmployeeId = Guid.Empty;

                    _context.ProjectActions.Update(ele);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                _context.ProjectEmployeeManagers.Remove(project);
                await _context.SaveChangesAsync(cancellationToken);

                return project;
            }
        }
    }
}
