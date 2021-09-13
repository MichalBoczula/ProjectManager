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

namespace Application.Features.ManagerProjectAction.Commands.CreateNewProject
{
    public class CreateNewProjectCommandHandler : IRequestHandler<CreateNewProjectCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public CreateNewProjectCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNewProjectCommand request, CancellationToken cancellationToken)
        {
            var result = CreateNewProjectCommandValidator.Validate(request);
            if(result.Item1)
            {
                return Guid.Empty;
            }

            var mangerId = await (from m in _context.Managers
                                  where m.Email == request.Email
                                  select m.Id).FirstOrDefaultAsync(cancellationToken);
            if(mangerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var project = new Project()
            {
                Title = request.Title,
                Description = request.Description,
                StatusId = 1,
                Status = ProjectStatus.Open
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync(cancellationToken);
            
            return project.Id;
        }
    }
}
