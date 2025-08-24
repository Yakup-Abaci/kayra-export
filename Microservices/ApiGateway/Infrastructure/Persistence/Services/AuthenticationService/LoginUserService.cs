using Application.Abstractions.Services.IAuthenticationService;
using Application.Abstractions.Services.ITokenService;
using Application.DTOs.LoginUser;
using Application.DTOs.Token;
using Domain.Entities.User.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.AuthenticationService
{
    public class LoginUserService : ILoginUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginUserService(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request)
        {
            AppUser user = await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
            {
                return LoginUserResponse.Failed(isSuccedeed: false,Message:"Email Bulunamadı");
            }
            SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            
            if(result.Succeeded)
            {
                Token token = _tokenService.CreateAccessToken(request.Email,5);
                return LoginUserResponse.Succedeed(isSuccedeed: true, token: token.AccessToken);
            }
            return LoginUserResponse.Failed(isSuccedeed: false, Message: "Hatalı Şifre");
        }
    }
}
