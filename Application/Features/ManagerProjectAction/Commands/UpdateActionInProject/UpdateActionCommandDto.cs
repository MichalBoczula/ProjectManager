using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.UpdateActionInProject
{
    public class UpdateActionCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
    }
}
