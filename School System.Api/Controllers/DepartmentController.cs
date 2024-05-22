using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Core.Features.Departments.Queries.Models;

namespace School_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion
        #region Constructors
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region Actions
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var response = await _mediator.Send(new GetSingleDepartmentQuery(id));
            if (response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments([FromQuery] GetAllDepartmentsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDepartmentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDepartmentCommand deleteDepartmentCommand)
        {
            var response = await _mediator.Send(deleteDepartmentCommand);
            if (response == false)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(EditDepartmentCommand editDepartmentCommand)
        {
            var response = await _mediator.Send(editDepartmentCommand);
            if (response == false)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion
    }
}
