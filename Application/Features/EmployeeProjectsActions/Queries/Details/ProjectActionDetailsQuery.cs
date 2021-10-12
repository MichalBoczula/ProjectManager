using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Queries.Details
{
    public class ProjectActionDetailsQuery : IRequest<ProjectActionDetailsQueryResult>
    {
        public string Email { get; set; }
        public string ProjectActionId { get; set; }
    }
}
