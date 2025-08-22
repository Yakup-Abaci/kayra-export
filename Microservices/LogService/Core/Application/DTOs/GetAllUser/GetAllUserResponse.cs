using Domain.Entities.User.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GetAllUser
{
    public class GetAllUserResponse
    {
        public List<AppUser> Users { get; set; }
    }
}
