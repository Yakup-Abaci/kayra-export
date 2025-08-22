using Domain.Entities.User.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUserQueryResponse
    {
        public List<AppUser> Users {  get; set; }
    }
}
