using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.Accept
{
    public class AcceptActionAfterCheckCommand : IRequest<Guid>
    {
        public string ProjectActionId { get; set; }
        public string Email { get; set; }
    }
}
