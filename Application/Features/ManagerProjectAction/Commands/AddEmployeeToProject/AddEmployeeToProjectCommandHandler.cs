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

namespace Application.Features.ManagerProjectAction.Commands.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommandHandler : IRequestHandler<AddEmployeeToProjectCommand, ProjectEmployeeManager>
    {
        private readonly IProjectManagerDbContext _context;

        public AddEmployeeToProjectCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEmployeeManager> Handle(AddEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);

            if (managerId == Guid.Empty)
            {
                return null;
            }

            if (!Guid.TryParse(request.EmployeeId, out Guid empId))
            {
                return null;
            }

            if (!Guid.TryParse(request.ProjectId, out Guid projId))
            {
                return null;
            }

            var checkProjExists = await (from p in _context.Projects
                                         where p.Id == projId
                                         select p).FirstOrDefaultAsync(cancellationToken);

            if (checkProjExists == null)
            {
                return null;
            }

            var checkEmpExists = await (from e in _context.Employees
                                        where e.Id == empId
                                        select e).FirstOrDefaultAsync(cancellationToken);

            if (checkEmpExists == null)
            {
                return null;
            }

            var projectEmployeeManager = await (from pem in _context.ProjectEmployeeManagers
                                                where pem.EmployeeId == empId
                                                    && pem.ProjectId == projId
                                                select pem).FirstOrDefaultAsync(cancellationToken);

            if (projectEmployeeManager == null)
            {
                var pem = new ProjectEmployeeManager()
                {
                    ProjectId = projId,
                    EmployeeId = empId,
                    ManagerId = managerId
                };

                await _context.ProjectEmployeeManagers.AddAsync(pem, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return pem;
            }
            else
            {
                return null;
            }
        }
    }
}
