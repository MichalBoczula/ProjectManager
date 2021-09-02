using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Commands.SendActionToCheck
{
    public class SendActionToCheckCommand : IRequest<Guid>
    {
        public string ProjectActionId { get; set; }
    }
}
