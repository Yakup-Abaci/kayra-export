using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddUser
{
    public class AddUserResponse
    {
        public bool isSuccedeed { get; set; }
        public string token { get; set; }
        public string Message { get; set; }

        public static AddUserResponse Succedeed(bool isSuccedeed, string token)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                token = token
            };
        }

        public static AddUserResponse Failed(bool isSuccedeed, string Message)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
