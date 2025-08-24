using Domain.Entities.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class KayraDbContext : DbContext
    {
        public KayraDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Product> Products { get; set; }
    }
}
