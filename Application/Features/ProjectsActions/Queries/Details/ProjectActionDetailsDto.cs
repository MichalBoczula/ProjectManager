using System;

namespace Application.Features.ProjectsActions.Queries.Details
{
    public class ProjectActionDetailsDto
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
        public DateTimeOffset Established { get; set; }
        public DateTimeOffset Done { get; set; }
        public DateTimeOffset DeadLine { get; set; }
    }
}