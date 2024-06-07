using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_System.Api.Controllers.Base;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Core.Features.Departments.Queries.Models;

namespace School_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppBaseController
    {
        #region Actions
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var response = await Mediator.Send(new GetSingleDepartmentQuery(id));
            if (response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments([FromQuery] GetAllDepartmentsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDepartmentCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDepartmentCommand deleteDepartmentCommand)
        {
            var response = await Mediator.Send(deleteDepartmentCommand);
            if (response == false)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(EditDepartmentCommand editDepartmentCommand)
        {
            var response = await Mediator.Send(editDepartmentCommand);
            if (response == false)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion
    }
}
