using Application.Features.ManagerProjectAction.Commands.CreateNewProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.RemoveEmployeeFromProject
{
    public static class RemoveEmployeeFromProjectCommandValidator
    {
        public static Tuple<bool, Exception> Validate(CreateNewProjectCommand command)
        {
            var result = false;
            if (String.IsNullOrWhiteSpace(command.Title))
            {
                result = true;
            }

            if (String.IsNullOrWhiteSpace(command.Description))
            {
                result = true;
            }
            return Tuple.Create(result, new Exception());
        }
    }
}
