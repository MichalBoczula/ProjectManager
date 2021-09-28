using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.UpdateProject
{
    public class UpdateProjectCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
