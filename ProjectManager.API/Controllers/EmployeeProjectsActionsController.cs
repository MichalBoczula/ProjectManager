using Application.Features.EmployeeProjectsActions.Commands.SendActionToCheck;
using Application.Features.EmployeeProjectsActions.Queries.Details;
using Application.Features.EmployeeProjectsActions.Queries.List;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeProjectsActionsController : BaseController
    {
        [HttpGet("{email}/projects")]
        public async Task<ActionResult<List<ProjectVm>>> GetList(string email)
        {
            var vm = await Mediator.Send(new ProjectsListForEmployeeQuery() { Email = email });
            if (vm != null)
            {
                return Ok(vm);
            }
            else
            {
                return NotFound(vm);
            }
        }

        [HttpGet("{email}/actions/{actionId}")]
        public async Task<ActionResult<ProjectActionDetailsVm>> GetDetails(string actionId)
        {
            var vm = await Mediator.Send(new ProjectActionDetailsQuery { ProjectActionId = actionId });
            if (vm != null)
            {
                return Ok(vm);
            }
            else
            {
                return NotFound(vm);
            }
        }

        [HttpPut("{email}/actions/{actionId}")]
        public async Task<ActionResult<ProjectActionDetailsVm>> SendActionToCheck(string actionId)
        {
            var vm = await Mediator.Send(new SendActionToCheckCommand { ProjectActionId = actionId });
            if (vm == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
