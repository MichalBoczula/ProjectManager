using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    public class ProjectActionWithFilterQuery
    {
        public string ActionStatus { get; set; }
        public string ActionName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
    }
}
