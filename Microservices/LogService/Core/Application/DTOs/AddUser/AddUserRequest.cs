using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddUser
{
    public class AddUserRequest
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
