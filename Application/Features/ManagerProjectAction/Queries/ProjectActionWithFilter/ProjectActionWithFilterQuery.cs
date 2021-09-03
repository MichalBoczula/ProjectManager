using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    public class ProjectActionWithFilterQuery : IRequest<List<ProjectActionWithFilterVm>>
    {
        public string Email { get; set; }
        public string ActionStatus { get; set; }
        public string ActionName { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
