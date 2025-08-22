using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class Service<T> where T : BaseEntity
    {
        private readonly KayraDbContext _dbContext;
        public Service(KayraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
