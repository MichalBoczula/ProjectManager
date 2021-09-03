using Application.Features.ManagerProjectAction.Commands.Accept;
using Application.Features.ManagerProjectAction.Queries.EmployeesList;
using Application.Features.ManagerProjectAction.Queries.ProjectDetails;
using Application.Features.ManagerProjectAction.Queries.ProjectsList;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerProjectActionController : BaseController
    {
        [HttpGet("projects/{Email}")]
        public async Task<ActionResult<List<ProjectForManagersList>>> GetProjectList(string Email)
        {
            var vm = await Mediator.Send(new ProjectListForManagerQuery { Email = Email });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpGet("employees/{Email}")]
        public async Task<ActionResult<EmployeeForManagerVm>> GetEmployeeList(string Email)
        {
            var vm = await Mediator.Send(new EmployeeListFormManagerQuery() { Email = Email });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpGet("projects/{Email}/{Id}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> GetProjectDetails(string Email, string Id)
        {
            var vm = await Mediator.Send(new ManagerProjectDetailsQuery() { Email = Email, ProjectId = Id });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpPut("actions/{Email}/{Id}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> CheckAction (
            string Email,
            string Id,
            [FromBody] bool isAccepted,
            [FromBody] string desc)
        {
            var vm = await Mediator.Send(new AcceptActionAfterCheckCommand() { Email = Email, ProjectActionId = Id });
            return vm != Guid.Empty ?
                NoContent() :
                NotFound(vm);
        }
    }
}
