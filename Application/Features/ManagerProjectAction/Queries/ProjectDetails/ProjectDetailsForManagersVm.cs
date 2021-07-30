using Domain.Entities;
using System.Collections.Generic;

namespace Application.Features.ManagerProjectAction.Queries.ProjectDetails
{
    public class ProjectDetailsForManagersVm
    {
        public ProjectForManagersDto Project { get; set; }
        public ICollection<ProjectActionForMangersProjectDetailsDto> ProjectActions { get; set; }
        
        public ProjectDetailsForManagersVm()
        {
            ProjectActions = new List<ProjectActionForMangersProjectDetailsDto>();
        }
    }
}