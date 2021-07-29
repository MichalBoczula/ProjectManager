using Application.Contracts.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.UpdateActionInProject
{
    public class UpdateActionCommandHandler : IRequestHandler<UpdateActionCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public UpdateActionCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateActionCommand request, CancellationToken cancellationToken)
        {
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == request.Id
                                select pa).FirstOrDefaultAsync(cancellationToken);
            if(action == null)
            {
                return Guid.Empty;
            }

            UpdateActionCommandValidator.Validate(action, request);

            _context.ProjectActions.Update(action);
            await _context.SaveChangesAsync(cancellationToken);

            return action.Id;
        }
    }
}
