using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectEmployeeManager
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
