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

namespace Application.Features.ManagerProjectAction.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public UpdateProjectCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);

            if (managerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            if (!Guid.TryParse(request.ProjectId, out Guid projectId))
            {
                return Guid.Empty;
            }

            var project = await (from p in _context.Projects
                                 where p.Id == projectId
                                 select p)
                                .FirstOrDefaultAsync(cancellationToken);

            if (project == null)
            {
                return Guid.Empty;
            }

            var isProjectExists = await (from pem in _context.ProjectEmployeeManagers
                                         where pem.ManagerId == managerId
                                            && pem.ProjectId == projectId
                                         select pem)
                                         .Distinct()
                                         .FirstOrDefaultAsync(cancellationToken);

            if (isProjectExists == null)
            {
                return Guid.Empty;
            }

            if (String.IsNullOrWhiteSpace(request.Title))
            {
                return Guid.Empty;
            }

            if (String.IsNullOrWhiteSpace(request.Description))
            {
                return Guid.Empty;
            }

            if (String.IsNullOrWhiteSpace(request.Status))
            {
                return Guid.Empty;
            }

            if (request.Status.ToLower() != "open" && request.Status.ToLower() != "close")
            {
                return Guid.Empty;
            }
            else if(request.Status.ToLower() == "open")
            {
                project.Status = ProjectStatus.Open;
            }
            else
            {
                project.Status = ProjectStatus.Close;
            }

            project.Title = request.Title;
            project.Description = request.Description;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return project.Id;
        }

    }
}
