using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.EmployeeProjectsActions.Queries.List
{
    public class ProjectVm
    {
        public ProjectInformationDto Project { get; set; }
        public List<ProjectActionDto> ProjectActions { get; set; }
    }
}