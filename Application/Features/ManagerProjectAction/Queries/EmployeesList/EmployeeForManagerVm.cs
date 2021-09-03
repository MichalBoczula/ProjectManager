using System;

namespace Application.Features.ManagerProjectAction.Queries.EmployeesList
{
    public class EmployeeForManagerVm
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}