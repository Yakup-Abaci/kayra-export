using KayraExportAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace KayraExportAPI.Context
{
    public class KayraExportDbContext : DbContext
    {
        public KayraExportDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
