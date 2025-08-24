using Application.Abstractions.Services.ICacheService;
using Infrastructure.Services.CacheService;
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
            serviceCollection.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(redisConnection));

            serviceCollection.AddScoped<ICacheService, CacheService>();
        }
    }
}
