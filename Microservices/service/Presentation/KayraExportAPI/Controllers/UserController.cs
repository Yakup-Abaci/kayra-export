using Application.Features.Commands.Users.AddUser;
using Application.Features.Queries.Users.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KayraExportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUserQueryRequest request = new();
            GetAllUserQueryResponse response = await _mediator.Send(request);

            return Ok(response.Users);
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommandRequest request)
        {
            AddUserCommandResponse response = await _mediator.Send(request);

            if(response.isSuccedeed)
            {
                return Ok(response.token);
            }
            return BadRequest(response.Message);
        }*/
    }
}
