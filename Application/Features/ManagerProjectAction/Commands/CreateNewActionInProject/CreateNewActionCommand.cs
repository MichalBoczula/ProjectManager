using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.CreateNewActionInProject
{
    public class CreateNewActionCommand : IRequest<Guid>
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public string Email { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
