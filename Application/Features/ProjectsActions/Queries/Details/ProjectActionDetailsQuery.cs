using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectsActions.Queries.Details
{
    public class ProjectActionDetailsQuery : IRequest<ProjectActionDetailsVm>
    {
        public Guid ProjectActionId { get; set; }
    }
}
