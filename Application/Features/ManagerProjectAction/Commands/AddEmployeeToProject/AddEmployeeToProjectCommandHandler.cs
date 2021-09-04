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

            var project = await (from pem in _context.ProjectEmployeeManagers
                                 where pem.EmployeeId == request.EmployeeId
                                 && pem.ManagerId == managerId
                                 && pem.ProjectId == request.ProjectId
                                 select pem).FirstOrDefaultAsync(cancellationToken);

            if(project == null)
            {
                var pem = new ProjectEmployeeManager()
                {
                    ProjectId = request.ProjectId,
                    EmployeeId = request.EmployeeId,
                    ManagerId = managerId
                };
                await _context.ProjectEmployeeManagers.AddAsync(pem);
                return pem;
            }  
            else
            {
                return null;
            }
        }
    }
}
