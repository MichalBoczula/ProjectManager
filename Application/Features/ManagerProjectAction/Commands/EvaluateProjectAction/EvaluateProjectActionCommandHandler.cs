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

namespace Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction
{
    public class EvaluateProjectActionCommandHandler : IRequestHandler<EvaluateProjectActionCommand, Guid>
    {
        private readonly IProjectManagerDbContext _context;

        public EvaluateProjectActionCommandHandler(IProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(EvaluateProjectActionCommand request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
           
            if (managerId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var project = await (from pa in _context.ProjectActions
                                 where pa.Id == new Guid(request.ProjectActionId)
                                    && pa.ManagerId == managerId
                                    && pa.Status == ProgressStatus.ToCheck
                                 select pa).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (project == null)
            {
                return Guid.Empty;
            }

            if(request.IsAccepted == true)
            {
                project.Status = ProgressStatus.Done;
                project.Done = DateTimeOffset.Now;
                project.Feedback = request.Feedback;

                _context.ProjectActions.Update(project);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else if(request.IsAccepted == false)
            {
                project.Status = ProgressStatus.ToImprove;
                project.Modified = DateTimeOffset.Now;
                project.Feedback = request.Feedback;

                _context.ProjectActions.Update(project);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return Guid.Empty;
            }

            return project.Id;
        }
    }
}
