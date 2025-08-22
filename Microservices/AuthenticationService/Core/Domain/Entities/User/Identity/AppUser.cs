using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefrestTokenEndTime { get; set; }
    }
}
