using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectsActions.Queries.List
{
    public class ProjectTempVm
    {
        public Guid ProjectId { get; set; }
        public List<ProjectActionDto> ProjectActions { get; set; }
    }
}
