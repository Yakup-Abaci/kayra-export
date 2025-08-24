using Application.DTOs.LoginUser;
using Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.IAuthenticationService
{
    public interface ILoginUserService
    {
        Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);
    }
}
