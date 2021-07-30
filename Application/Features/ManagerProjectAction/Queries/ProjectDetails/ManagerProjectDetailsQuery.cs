using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectDetails
{
    public class ManagerProjectDetailsQuery : IRequest<ProjectDetailsForManagersVm>
    {
        public Guid ProjectId { get; set; }
    }
}
