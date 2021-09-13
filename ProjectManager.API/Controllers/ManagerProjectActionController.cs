using Application.Features.ManagerProjectAction.Commands.AddEmployeeToProject;
using Application.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction;
using Application.Features.ManagerProjectAction.Commands.CreateNewActionInProject;
using Application.Features.ManagerProjectAction.Commands.CreateNewProject;
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

        [HttpGet("actions/{Email}")]
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

        [HttpPost("projects/{Email}/{ProjId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> AddEmployeeToProject(
            string Email,
            string ProjId,
            AddEmployeeToProjectDto data)
        {
            var vm = await Mediator.Send(new AddEmployeeToProjectCommand()
            {
                Email = Email,
                ProjectId = ProjId,
                EmployeeId = data.EmployeeId
            });
            return vm != null ?
                Ok() :
                NotFound();
        }

        [HttpPut("projects/actions/{Email}/{ActId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> ChangeEmployeeInAction(
            string Email,
            string ActId,
            AddEmployeeToProjectDto data)
        {
            var vm = await Mediator.Send(new ChangeEmployeeInProjectActionCommand()
            {
                Email = Email,
                ActionId = ActId,
                EmployeeId = data.EmployeeId
            });
            return vm != Guid.Empty ?
                NoContent() :
                NotFound();
        }

        [HttpPost("projects/actions/{Email}/{ProjectId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> AddActionToProject(
            string Email,
            string ProjectId,
            CreateNewActionInProjectDto data)
        {
            var vm = await Mediator.Send(new CreateNewActionCommand() 
            { 
                Email = Email,
                ProjectId = ProjectId, 
                Title = data.Title,
                Description = data.Description,
                EmployeeId = data.EmployeeId,
                DeadLine = data.DeadLine
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }

        [HttpPost("projects/{Email}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> CreateNewProject(
            string Email,
            CreateNewProjectDto data)
        {
            var vm = await Mediator.Send(new CreateNewProjectCommand()
            {
                Email = Email,
                Title = data.Title,
                Description = data.Description,
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }
    }
}
