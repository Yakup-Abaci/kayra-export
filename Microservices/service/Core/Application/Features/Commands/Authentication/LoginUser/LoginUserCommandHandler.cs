using Application.Abstractions.Services.IAuthenticationService;
using Application.DTOs.LoginUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Authentication.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly ILoginUserService _service;
        public LoginUserCommandHandler(ILoginUserService service)
        {
            _service = service;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginUserResponse response = await _service.LoginUserAsync(new()
            {
                Email = request.Email,
                Password = request.Password,
            });

            if(response.isSuccedeed)
            {
                return LoginUserCommandResponse.Succedeed(isSuccedeed:response.isSuccedeed,token:response.token);
            }
            return LoginUserCommandResponse.Failed(isSuccedeed: response.isSuccedeed, Message: response.Message);
        }
    }
}
