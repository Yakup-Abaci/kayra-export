using Application.Abstractions.Services.TokenService;
using Application.DTOs.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.TokenService
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(string UserEmail, int LiteTimeMinute)
        {
            Token token = new();

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

            token.LifeTime = DateTime.UtcNow.AddMinutes(LiteTimeMinute);
            List<Claim> token_claims = new()
            {
                new Claim("Email", UserEmail ?? "")
            };

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.LifeTime,//süresi
                notBefore: DateTime.UtcNow,//başlama anı ne zaman olacak
                signingCredentials: signingCredentials,
                claims: token_claims
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);


            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] data = new byte[32];
            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(data);
            return Convert.ToBase64String(data);
        }
    }
}
