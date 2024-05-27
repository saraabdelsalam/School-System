using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_System.Api.Controllers.Base;
using School_System.Core.Features.Students.Commands.Models;
using School_System.Core.Features.Students.Queries.Models;

namespace School_System.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StudentsController : AppBaseController
    {
       
        [HttpGet("List")]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await Mediator.Send(new GetStudentsListQuery());
            if (response.Count() < 1)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("Paginated")]
        public async Task<IActionResult> GetAllStudentsPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await Mediator.Send(new GetSingleStudentQuery(id));
            if (response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteStudentCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
