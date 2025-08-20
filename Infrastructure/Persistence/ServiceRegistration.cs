using Application.Abstractions.Services.IProductService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
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
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<KayraDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            service.AddScoped<IProductService,ProductService>();
        }
        
    }
}
