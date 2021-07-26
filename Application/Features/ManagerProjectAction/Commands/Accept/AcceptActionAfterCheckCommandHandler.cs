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
            var action = await (from pa in _context.ProjectActions
                               where request.ProjectActionId == pa.Id
                               select pa).FirstOrDefaultAsync(cancellationToken);

            action.Status = ProgressStatus.Done;
            action.Done = DateTimeOffset.Now;

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
