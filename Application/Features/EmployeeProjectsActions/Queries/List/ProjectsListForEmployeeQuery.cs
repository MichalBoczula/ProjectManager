using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Queries.List
{
    public class ProjectsListForEmployeeQuery : IRequest<List<ProjectVm>>
    {
        public string Email { get; set; }
    }
}
