using Application.Features.ManagerProjectAction.Commands.Accept;
using Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction;
using Application.Features.ManagerProjectAction.Queries.EmployeesList;
using Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter;
using Application.Features.ManagerProjectAction.Queries.ProjectDetails;
using Application.Features.ManagerProjectAction.Queries.ProjectsList;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpGet("projects/{Email}/actions")]
        public async Task<ActionResult<List<ProjectActionWithFilterVm>>> GetActions(
            string Email,
            [FromQuery] string ActionName,
            [FromQuery] string ActionStatus,
            [FromQuery] int Skip,
            [FromQuery] int Take)
        {

            var vm = await Mediator.Send(new ProjectActionWithFilterQuery() 
            { 
                Email = Email,
                ActionName = ActionName,
                ActionStatus = ActionStatus,
                Skip = Skip,
                Take = Take
            });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpPut("actions/{Email}/{Id}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> CheckAction(
            string Email,
            string Id,
            EvaluateProjectActionDto data)
        {
            var vm = await Mediator.Send(new EvaluateProjectActionCommand()
            {
                Email = Email,
                ProjectActionId = Id,
                IsAccepted = data.IsAccepted,
                Feedback = data.Feedback
            }); ;
            return vm != Guid.Empty ?
                NoContent() :
                NotFound(vm);
        }
    }
}
