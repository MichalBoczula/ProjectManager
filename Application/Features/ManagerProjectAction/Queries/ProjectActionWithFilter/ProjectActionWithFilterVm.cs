using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    public class ProjectActionWithFilterVm
    {
        public ProjectForProjectActionWithFilterDto Project { get; set; }
        public ICollection<ProjectActionForProjectActionWithFilterDto> ProjectActions { get; set; }
    }
}
