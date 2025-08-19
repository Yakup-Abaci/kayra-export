using KayraExportAPI.Context;
using KayraExportAPI.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KayraExportAPI.Contretes.ProductContretes
{
    public class ProductWriteConcretes
    {
        private readonly KayraExportDbContext _context;
        private readonly ProductReadConcretes _readConcretes;
        public ProductWriteConcretes(KayraExportDbContext context, ProductReadConcretes readConcretes)
        {
            _context = context;
            _readConcretes = readConcretes;
        }

        public async Task<bool> AddProductAsync(ProductModal product)
        {
            EntityEntry<Entities.Product> result = await _context.Products.AddAsync(new()
            {
                Ad=product.Ad,
                Adet=product.Adet,
                Fiyat=product.Fiyat
            });
            //await _context.SaveChangesAsync();
            return result.State == EntityState.Added;
        }

        public async Task<bool> UpdateProduct(int id, ProductModal product)
        {
            EntityEntry entity = _context.Products.Update(new()
            {
                Id=id,
                Ad=product.Ad,
                Adet=product.Adet,
                Fiyat=product.Fiyat
            });
            //await _context.SaveChangesAsync();
            return entity.State == EntityState.Modified;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var delete_product =  await _readConcretes.GetByIdProductAsync(id);
            EntityEntry entity = _context.Products.Remove(delete_product);
            //await _context.SaveChangesAsync();
            return entity.State == EntityState.Deleted;
        }

        public async Task<int> SaveCahngesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
