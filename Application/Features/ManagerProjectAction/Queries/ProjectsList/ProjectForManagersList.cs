using System;

namespace Application.Features.ManagerProjectAction.Queries.ProjectsList
{
    public class ProjectForManagersList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}