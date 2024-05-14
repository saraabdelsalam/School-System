using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_System.Core.Features.Students.Commands.Models;
using School_System.Core.Features.Students.Queries.Models;

namespace School_System.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("List")]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _mediator.Send(new GetStudentsListQuery());
            if (response.Count() < 1)
                return NoContent();

            return Ok(response);


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _mediator.Send(new GetSingleStudentQuery(id));
            if (response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == "Failed")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditStudentCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
