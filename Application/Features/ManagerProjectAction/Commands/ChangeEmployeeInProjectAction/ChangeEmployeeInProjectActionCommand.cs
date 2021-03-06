using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction
{
    public class ChangeEmployeeInProjectActionCommand : IRequest<Guid>
    {
        public string ActionId { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
    }
}
