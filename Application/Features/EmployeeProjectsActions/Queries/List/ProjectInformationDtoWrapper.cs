using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Queries.List
{
    public class ProjectInformationDtoWrapper
    {
        public Guid Id { get; set; }
        public ProjectInformationDto ProjectDto { get; set; }
    }
}
