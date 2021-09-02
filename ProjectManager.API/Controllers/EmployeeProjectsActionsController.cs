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
        [HttpGet("{Email}")]
        public async Task<ActionResult<List<ProjectVm>>> GetList(string Email)
        {
            var vm = await Mediator.Send(new ProjectsListForEmployeeQuery() { Email = Email });
            if (vm != null)
            {
                return Ok(vm);
            }
            else
            {
                return NotFound(vm);
            }
        }

        [HttpGet("actions/{Id}")]
        public async Task<ActionResult<ProjectActionDetailsVm>> GetDetails(string Id)
        {
            var vm = await Mediator.Send(new ProjectActionDetailsQuery { ProjectActionId = Id });
            if (vm != null)
            {
                return Ok(vm);
            }
            else
            {
                return NotFound(vm);
            }
        }

        [HttpPut("actions/{Id}")]
        public async Task<ActionResult<ProjectActionDetailsVm>> SendActionToCheck(string Id)
        {
            var vm = await Mediator.Send(new SendActionToCheckCommand { ProjectActionId = Id });
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
