using Application.Abstractions.Services.IUserService;
using Application.DTOs.AddUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace Application.Features.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly IUserService _userService;
        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            AddUserResponse response = await _userService.AddUserAsync(new()
            {
                NameSurname = request.NameSurname,
                Email = request.Email,
                Password = request.Password,
            });

            if (response.isSuccedeed)
            {
                return AddUserCommandResponse.Succedeed(response.isSuccedeed, response.token);
            }
            return AddUserCommandResponse.Failed(response.isSuccedeed, response.Message);
        }
    }
}
