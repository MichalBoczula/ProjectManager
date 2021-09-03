using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    public class ProjectActionForProjectActionWithFilterDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
