using Application.Contracts.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction
{
    public class ChangeEmployeeInProjectActionCommandHandler : IRequestHandler<ChangeEmployeeInProjectActionCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public ChangeEmployeeInProjectActionCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(ChangeEmployeeInProjectActionCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);

            if (managerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            if (!Guid.TryParse(request.ActionId, out Guid actId))
            {
                return Guid.Empty;
            }

            if (!Guid.TryParse(request.EmployeeId, out Guid empId))
            {
                return Guid.Empty;
            }

            var action = await (from pa in _context.ProjectActions
                                where pa.Id == actId
                                select pa).FirstOrDefaultAsync(cancellationToken);

            if (action == null)
            {
                return Guid.Empty;
            }

            var employee = await (from e in _context.Employees
                                  where e.Id == empId
                                  select e).FirstOrDefaultAsync(cancellationToken);

            if (employee == null)
            {
                return Guid.Empty;
            }

            var checkIsEmployeeAssignedToProject = await (from pem in _context.ProjectEmployeeManagers
                                                          where pem.EmployeeId == empId
                                                               && pem.ProjectId == action.ProjectId
                                                          select pem).FirstOrDefaultAsync(cancellationToken);

            if (checkIsEmployeeAssignedToProject == null)
            {
                return Guid.Empty;
            }

            action.EmployeeId = empId;

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
