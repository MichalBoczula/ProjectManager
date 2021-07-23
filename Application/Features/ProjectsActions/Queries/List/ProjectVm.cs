using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.ProjectsActions.Queries.List
{
    public class ProjectVm
    {
        public ProjectInformationDto Project { get; set; }
        public List<ProjectActionDto> ProjectActions { get; set; }
    }
}