using Application.Abstractions.Services.IAuthenticationService;
using Application.Abstractions.Services.ICacheService;
using Application.Abstractions.Services.IProductService;
using Application.Abstractions.Services.IUserService;
using Domain.Entities.User.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Services;
using Persistence.Services.AuthenticationService;
using Persistence.Services.ProductServices;
using Persistence.Services.UserService;
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
            service.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<KayraDbContext>();
            service.AddScoped<IProductService,ProductService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ILoginUserService, LoginUserService>();
        }
        
    }
}
