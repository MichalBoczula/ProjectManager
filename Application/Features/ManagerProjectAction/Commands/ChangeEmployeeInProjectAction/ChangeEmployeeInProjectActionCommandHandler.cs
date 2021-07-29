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
            var employeeId = await (from e in _context.Employees
                                  where e.Id == request.EmployeeId
                                  select e.Id).FirstOrDefaultAsync(cancellationToken);
            if (employeeId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var action = await (from pa in _context.ProjectActions
                                where pa.Id == request.ActionId
                                select pa).FirstOrDefaultAsync(cancellationToken);
            if(action == null)
            {
                return Guid.Empty;
            }

            action.EmployeeId = request.EmployeeId;

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
