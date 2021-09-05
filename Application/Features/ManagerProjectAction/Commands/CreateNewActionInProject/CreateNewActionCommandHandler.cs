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

            if (managerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            if (!Guid.TryParse(request.ProjectId, out Guid projId))
            {
                return Guid.Empty;
            }

            if (!Guid.TryParse(request.EmployeeId, out Guid empId))
            {
                return Guid.Empty;
            }

            if (!DateTimeOffset.TryParse(request.DeadLine, out DateTimeOffset deadline))
            {
                return Guid.Empty;
            }

            var checkIsProjectExists = await (from p in _context.Projects
                                              where p.Id == projId
                                              select p).FirstOrDefaultAsync(cancellationToken);

            if (checkIsProjectExists == null)
            {
                return Guid.Empty;
            }

            var checkIsEmployeeExists = await (from e in _context.Employees
                                               where e.Id == empId
                                               select e).FirstOrDefaultAsync(cancellationToken);

            if (checkIsEmployeeExists == null)
            {
                return Guid.Empty;
            }

            var checkIsActionExists = await (from pa in _context.ProjectActions
                                             where pa.ProjectId == projId
                                                && pa.Title.Equals(request.Title.Trim())
                                                && pa.Description.Equals(request.Description.Trim())
                                             select pa.Id).FirstOrDefaultAsync();

            if (checkIsActionExists != Guid.Empty)
            {
                return Guid.Empty;
            }
            else
            {

                var action = new ProjectAction()
                {
                    ProjectId = projId,
                    Title = request.Title.Trim(),
                    Description = request.Description.Trim(),
                    DeadLine = deadline,
                    EmployeeId = empId,
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
}
