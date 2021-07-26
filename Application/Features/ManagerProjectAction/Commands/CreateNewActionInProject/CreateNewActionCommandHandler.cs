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

namespace Application.Features.ManagerProjectAction.Commands.CreateNewActionInProject
{
    public class CreateNewActionCommandHandler : IRequestHandler<CreateNewActionCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public CreateNewActionCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNewActionCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);

            var action = new ProjectAction()
            {
                ProjectId = request.ProjectId,
                Title = request.Title,
                Description = request.Description,
                DeadLine = request.DeadLine,
                EmployeeId = request.EmployeeId,
                ManagerId = managerId,
                Status = ProgressStatus.ToDo,
                Feedback = "",
                StatusId = 1
            };

            await _context.ProjectActions.AddAsync(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
