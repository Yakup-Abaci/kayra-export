using Application.Abstractions.Services.ICacheService;
using Application.Abstractions.Services.ITokenService;
using Infrastructure.Services.CacheService;
using Infrastructure.Services.TokenService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, string redisConnection)
        {
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(redisConnection));

            serviceCollection.AddScoped<ICacheService, CacheService>();
        }
    }
}
