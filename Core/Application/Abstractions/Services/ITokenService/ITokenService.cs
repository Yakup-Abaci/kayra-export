using Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.ITokenService
{
    public interface ITokenService
    {
        Token CreateAccessToken(string UserEmail,int LiteTimeMinute);
        string CreateRefreshToken();

    }
}
