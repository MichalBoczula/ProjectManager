using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction
{
    public class EvaluateProjectActionDto
    {
        public string Feedback { get; set; }
        public bool? IsAccepted { get; set; }
    }
}
