using Application.Abstractions.Services.IAuthenticationService;
using Application.Features.Commands.Authentication.LoginUser;
using Application.Features.Commands.Users.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KayraExportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<AuthenticationController>
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response =  await _mediator.Send(request);

            if (response.isSuccedeed)
            {
                return Ok(response.token);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserCommandRequest request)
        {
            AddUserCommandResponse response = await _mediator.Send(request);

            if (response.isSuccedeed)
            {
                return Ok(response.token);
            }
            return BadRequest(response.Message);
        }

    }
}
