using Application.Features.ManagerProjectAction.Commands.AddEmployeeToProject;
using Application.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction;
using Application.Features.ManagerProjectAction.Commands.CreateNewActionInProject;
using Application.Features.ManagerProjectAction.Commands.CreateNewProject;
using Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction;
using Application.Features.ManagerProjectAction.Commands.RemoveEmployeeFromProject;
using Application.Features.ManagerProjectAction.Commands.UpdateActionInProject;
using Application.Features.ManagerProjectAction.Commands.UpdateProject;
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
        [HttpGet("{email}projects")]
        public async Task<ActionResult<List<ProjectForManagersList>>> GetProjectList(string email)
        {
            var vm = await Mediator.Send(new ProjectListForManagerQuery { Email = email });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpGet("{email}/employees")]
        public async Task<ActionResult<EmployeeForManagerVm>> GetEmployeeList(string email)
        {
            var result = await Mediator.Send(new EmployeeListFormManagerQuery() { Email = email });
            return result.AreThereException ?
                NotFound(result.ExceptionsList) :
                Ok(result.Vm);
        }

        [HttpGet("{email}/projects/{projectId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> GetProjectDetails(string email, string projectId)
        {
            var vm = await Mediator.Send(new ManagerProjectDetailsQuery() { Email = email, ProjectId = projectId });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpGet("{email}/actions")]
        public async Task<ActionResult<List<ProjectActionWithFilterVm>>> GetActions(
            string email,
            [FromQuery] string ActionName,
            [FromQuery] string ActionStatus,
            [FromQuery] int Skip,
            [FromQuery] int Take)
        {

            var vm = await Mediator.Send(new ProjectActionWithFilterQuery()
            {
                Email = email,
                ActionName = ActionName,
                ActionStatus = ActionStatus,
                Skip = Skip,
                Take = Take
            });
            return vm != null ?
                Ok(vm) :
                NotFound(vm);
        }

        [HttpPut("{email}/actions/{actId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> CheckAction(
            string email,
            string actId,
            EvaluateProjectActionDto data)
        {
            var vm = await Mediator.Send(new EvaluateProjectActionCommand()
            {
                Email = email,
                ProjectActionId = actId,
                IsAccepted = data.IsAccepted,
                Feedback = data.Feedback
            }); ;
            return vm != Guid.Empty ?
                NoContent() :
                NotFound(vm);
        }

        [HttpPost("{email}/projects/{projId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> AddEmployeeToProject(
            string email,
            string projId,
            AddEmployeeToProjectDto data)
        {
            var vm = await Mediator.Send(new AddEmployeeToProjectCommand()
            {
                Email = email,
                ProjectId = projId,
                EmployeeId = data.EmployeeId
            });
            return vm != null ?
                Ok() :
                NotFound();
        }

        [HttpPut("{email}/projects/actions/employees/{actId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> ChangeEmployeeInAction(
            string email,
            string actId,
            AddEmployeeToProjectDto data)
        {
            var vm = await Mediator.Send(new ChangeEmployeeInProjectActionCommand()
            {
                Email = email,
                ActionId = actId,
                EmployeeId = data.EmployeeId
            });
            return vm != Guid.Empty ?
                NoContent() :
                NotFound();
        }

        [HttpPost("{email}/projects/actions/{projectId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> AddActionToProject(
            string email,
            string projectId,
            CreateNewActionInProjectDto data)
        {
            var vm = await Mediator.Send(new CreateNewActionCommand()
            {
                Email = email,
                ProjectId = projectId,
                Title = data.Title,
                Description = data.Description,
                EmployeeId = data.EmployeeId,
                DeadLine = data.DeadLine
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }

        [HttpPost("{email}/projects")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> CreateNewProject(
            string email,
            CreateNewProjectDto data)
        {
            var vm = await Mediator.Send(new CreateNewProjectCommand()
            {
                Email = email,
                Title = data.Title,
                Description = data.Description,
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }

        [HttpDelete("{email}/projects/{projectId}")]
        public async Task<ActionResult<ProjectDetailsForManagersVm>> DeleteEmployeeFromProject(
            string email,
            string projectId,
            RemoveEmployeeFromProjectCommandDto data)
        {
            var vm = await Mediator.Send(new RemoveEmployeeFromProjectCommand()
            {
                Email = email,
                ProjectId = projectId,
                EmployeeId = data.EmployeeId,
            });
            return vm != null ?
                Ok() :
                NotFound();
        }

        [HttpPut("{email}/projects/actions/{actionId}")]
        public async Task<ActionResult<Guid>> UpdateProjectAction(
            string email,
            string actionId,
            UpdateActionCommandDto data)
        {
            var vm = await Mediator.Send(new UpdateActionCommand()
            {
                Email = email,
                ActionId = actionId,
                Title = data.Title,
                Description = data.Description,
                DeadLine = data.DeadLine
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }

        [HttpPut("{email}/projects/{projectId}")]
        public async Task<ActionResult<Guid>> UpdateProject(
            string email,
            string projectId,
            UpdateProjectCommandDto data)
        {
            var vm = await Mediator.Send(new UpdateProjectCommand()
            {
                Email = email,
                ProjectId = projectId,
                Title = data.Title,
                Description = data.Description,
                Status = data.Status
            });
            return vm != Guid.Empty ?
                Ok() :
                NotFound();
        }
    }
}
