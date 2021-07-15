using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectAction> ProjectActions { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<ProjectEmployeeManager> Projects { get; set; }
    }
}
