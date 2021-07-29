using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.UpdateActionInProject
{
    public static class UpdateActionCommandValidator
    {
        public static void Validate(ProjectAction action, UpdateActionCommand request)
        {
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                action.Title = request.Title;
            }
            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                action.Description = request.Description;
            }
            if (request.DeadLine != null)
            {
                action.DeadLine = request.DeadLine;
            }
        }
    }
}
