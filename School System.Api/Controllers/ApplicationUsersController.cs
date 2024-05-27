using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_System.Api.Controllers.Base;
using School_System.Core.Features.ApplicationUsers.Commands.Models;

namespace School_System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : AppBaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
