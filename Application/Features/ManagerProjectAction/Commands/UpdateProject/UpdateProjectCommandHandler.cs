using Application.Contracts.Persistance;
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
            var project = await (from p in _context.Projects
                          where p.Id == request.ProjectId
                          select p).FirstOrDefaultAsync(cancellationToken);
            if(project == null)
            {
                return Guid.Empty;
            }

            project.Title = request.Title;
            project.Description = request.Description;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return project.Id;
        }

        public object Handle(UpdateProjectCommand command, object none)
        {
            throw new NotImplementedException();
        }
    }
}
