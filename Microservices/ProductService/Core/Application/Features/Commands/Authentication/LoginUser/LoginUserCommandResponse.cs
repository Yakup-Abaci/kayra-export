using Application.DTOs.LoginUser;
using Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Authentication.LoginUser
{
    public class LoginUserCommandResponse
    {
        public bool isSuccedeed { get; set; }
        public string? token { get; set; }
        public string? Message { get; set; }

        public static LoginUserCommandResponse Succedeed(bool isSuccedeed, string token)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                token = token
            };
        }
        public static LoginUserCommandResponse Failed(bool isSuccedeed, string Message)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
