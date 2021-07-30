using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectsList
{
    public class ProjectListForManagerQuery : IRequest<List<ProjectForManagersList>>
    {
        public string Email { get; set; }
    }
}
