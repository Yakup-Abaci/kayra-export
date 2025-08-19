using KayraExportAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace KayraExportAPI.Contretes.ProductContretes
{
    public class ProductReadConcretes
    {
        private readonly KayraExportDbContext _context;
        
        public ProductReadConcretes(KayraExportDbContext context)
        {
            _context = context;
        }
       
        public IQueryable<Entities.Product> GetAllProduct()
        {
            var products = _context.Products.AsQueryable();
            return products;
        }

        public async Task<Entities.Product> GetByIdProductAsync(int id)
        {
            var product = _context.Products.AsQueryable();

            return await product.FirstOrDefaultAsync(data => data.Id.Equals(id));
        }
    }
}
