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

namespace Application.Features.ManagerProjectAction.Commands.ToImprove
{
    public class SendActionToImproveCommandHandler : IRequestHandler<SendActionToImproveCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public SendActionToImproveCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(SendActionToImproveCommand request, CancellationToken cancellationToken)
        {
            var action = await (from pa in _context.ProjectActions
                                where request.ProjectActionId == pa.Id
                                select pa).FirstOrDefaultAsync(cancellationToken);

            action.Feedback = request.Feedback;
            action.Status = ProgressStatus.ToImprove;

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
