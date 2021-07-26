using Domain.Common;
using System;

namespace Domain.Entities
{
    public class ProjectAction : AuditableEntity
    {
        public ProgressStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
        public DateTimeOffset Done { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}