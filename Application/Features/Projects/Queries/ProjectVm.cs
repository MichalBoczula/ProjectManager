using Domain.Entities;

namespace Application.Features.Projects.Queries
{
    public class ProjectVm
    {
        public ProjectInformationDto Project { get; set; }
        public ProjectActionDto ProjectAction { get; set; }
    }
}