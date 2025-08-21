using Domain.Entities.Product;
using Domain.Entities.User.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class KayraDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public KayraDbContext(DbContextOptions<KayraDbContext> options) : base(options){ }
        public DbSet<Product> Products { get; set; }
    }
}
