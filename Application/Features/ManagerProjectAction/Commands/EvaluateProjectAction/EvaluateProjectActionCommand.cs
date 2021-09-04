using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction
{
    public class EvaluateProjectActionCommand : IRequest<Guid>
    {
        public string ProjectActionId { get; set; }
        public string Email { get; set; }
        public string Feedback { get; set; }
        public bool? IsAccepted { get; set; }
    }
}
