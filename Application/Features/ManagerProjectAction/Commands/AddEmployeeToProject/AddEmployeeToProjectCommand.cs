using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Commands.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommand : IRequest<ProjectEmployeeManager>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
    }
}
