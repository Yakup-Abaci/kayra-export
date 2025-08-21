using Application.Abstractions.Services.IUserService;
using Application.Abstractions.Services.TokenService;
using Application.DTOs.AddUser;
using Application.DTOs.GetAllUser;
using Application.DTOs.Token;
using Application.Features.Commands.Users.AddUser;
using Domain.Entities.User.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _user;
        private readonly ITokenService _tokenService;
        public UserService(UserManager<AppUser> user, ITokenService tokenService)
        {
            _user = user;
            _tokenService = tokenService;
        }
        
        public async Task<AddUserResponse> AddUserAsync(AddUserRequest request)
        {
            IdentityResult result = await _user.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName = request.NameSurname
            },request.Password);

            if(result.Succeeded)
            {
                Token token = _tokenService.CreateAccessToken(request.Email, 5);
                return AddUserResponse.Succedeed(isSuccedeed: true, token: token.AccessToken);

            }
            else
            {
                string Message = "";
                foreach (var err in result.Errors)
                {
                    Message += err.Description;
                }
                return AddUserResponse.Failed(isSuccedeed:false, Message:Message);
            }
        }

        public async Task<GetAllUserResponse> GetAllUserAsync()
        {
            List<AppUser> users = await _user.Users.ToListAsync();

            return new()
            {
                Users = users
            };
        }
    }
}
