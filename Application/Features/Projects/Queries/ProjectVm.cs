using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.Projects.Queries
{
    public class ProjectVm
    {
        public ProjectInformationDto Project { get; set; }
        public List<ProjectActionDto> ProjectAction { get; set; }
    }
}