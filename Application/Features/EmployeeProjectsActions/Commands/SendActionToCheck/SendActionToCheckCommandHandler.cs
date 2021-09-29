using Application.Contracts.Persistance;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Commands.SendActionToCheck
{
    public class SendActionToCheckCommandHandler : IRequestHandler<SendActionToCheckCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public SendActionToCheckCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(SendActionToCheckCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.ProjectActionId, out Guid actionId))
            {
                return Guid.Empty;
            }

            var empId = await (from e in _context.Employees
                               where e.Email == request.Email
                               select e.Id)
                        .FirstOrDefaultAsync(cancellationToken);

            if (empId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var action = await (from pa in _context.ProjectActions
                                where pa.Id == actionId
                                    && pa.EmployeeId == empId
                                select pa)
                                .FirstOrDefaultAsync(cancellationToken);

            if (action == null)
            {
                return Guid.Empty;
            }

            action.Status = ProgressStatus.ToCheck;
            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);
            
            return action.Id;

        }
    }
}
