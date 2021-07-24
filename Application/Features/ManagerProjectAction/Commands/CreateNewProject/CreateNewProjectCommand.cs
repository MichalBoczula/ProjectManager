using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.CreateNewProject
{
    public class CreateNewProjectCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public HashSet<Guid> Employees { get; set; }
        //In futere get email from CurrentUserService
        public string Email { get; set; }
    }
}
