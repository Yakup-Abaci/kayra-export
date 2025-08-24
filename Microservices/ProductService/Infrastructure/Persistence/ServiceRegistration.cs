using Application.Abstractions.Services.IProductService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Services;
using Persistence.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            service.AddDbContext<KayraDbContext>(options =>
                options.UseSqlServer(connectionString));
            service.AddScoped<IProductService,ProductService>();
           
        }
        
    }
}
