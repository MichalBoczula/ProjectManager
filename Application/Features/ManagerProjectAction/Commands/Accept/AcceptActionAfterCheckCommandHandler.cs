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

namespace Application.Features.ManagerProjectAction.Commands.Accept
{
    public class AcceptActionAfterCheckCommandHandler : IRequestHandler<AcceptActionAfterCheckCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public AcceptActionAfterCheckCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AcceptActionAfterCheckCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                            where m.Email == request.Email
                            select m.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if(managerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var action = await (from pa in _context.ProjectActions
                         where new Guid(request.ProjectActionId) == pa.Id
                               && managerId == pa.ManagerId
                               && pa.Status == ProgressStatus.ToCheck
                         select pa).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (action == null)
            { 
                return Guid.Empty;
            }

            action.Status = ProgressStatus.Done;
            action.Done = DateTimeOffset.Now;

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
