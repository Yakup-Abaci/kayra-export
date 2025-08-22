using Application.Abstractions.Services.IUserService;
using Application.DTOs.GetAllUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllUserResponse response = await _userService.GetAllUserAsync();

            return new()
            {
                Users = response.Users,
            };
        }
    }
}
