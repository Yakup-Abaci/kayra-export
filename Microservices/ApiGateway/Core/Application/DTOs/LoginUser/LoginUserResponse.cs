using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LoginUser
{
    public class LoginUserResponse
    {
        public bool isSuccedeed { get; set; }
        public string? token { get; set; }
        public string? Message { get; set; }

        public static LoginUserResponse Succedeed(bool isSuccedeed, string token)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                token = token
            };
        }
        public static LoginUserResponse Failed(bool isSuccedeed, string Message)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
