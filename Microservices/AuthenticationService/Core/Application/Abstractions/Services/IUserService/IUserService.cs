using Application.DTOs.AddUser;
using Application.DTOs.GetAllUser;
using Application.Features.Commands.Users.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.IUserService
{
    public interface IUserService
    {
        Task<AddUserResponse> AddUserAsync(AddUserRequest request);
        Task<GetAllUserResponse> GetAllUserAsync();
    }
}
