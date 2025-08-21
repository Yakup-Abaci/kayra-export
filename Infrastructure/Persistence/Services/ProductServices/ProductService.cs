using Application.Abstractions.Services.IProductService;
using Application.DTOs.AddProduct;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Application.DTOs.GetAllProduct;
using Domain.Entities.Product;
using Application.DTOs.GetByIdProduct;
using Application.DTOs.UpdateProduct;
using Application.DTOs.DeleteProduct;

namespace Persistence.Services.ProductServices
{
    public class ProductService : Service<Product> , IProductService
    {
        public ProductService(KayraDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest request)
        {
            

            EntityEntry result = await Table.AddAsync(new()
            {
                Ad = request.Ad,
                Adet = request.Adet,
                Fiyat = request.Fiyat
            });
            if (result.State == EntityState.Added)
            {
                try
                {
                    await SaveChangesAsync();
                    return AddProductResponse.Succedeed(isSuccedeed: true,Message:"Ekleme İşlemi Başarılı");
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlEx)
                    {
                        return AddProductResponse.Failed(isSuccedeed:false, Message:sqlEx.Message);

                    }
                    return AddProductResponse.Failed(isSuccedeed: false, Message: ex.Message);

                }
            }
            return AddProductResponse.Failed(isSuccedeed: false, Message: "Ekleme Sırasında Biri Hata Oluştu");

        }

        public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request)
        {
            GetByIdProductResponse result = await GetByIdProductAsync(new()
            {
                Id = request.Id,
            });
            if (result.isFind == true)
            {
                EntityEntry entity = Table.Remove(result.product);

                if (entity.State == EntityState.Deleted)
                {
                    try
                    {
                        await SaveChangesAsync();
                        return new() 
                        { 
                            isSuccedeed = true,
                            Message = "Silme İşlemi Başarılı"
                        };
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException is SqlException sqlEx)
                        {
                            return new()
                            {
                                isSuccedeed = false,
                                Message = sqlEx.Message
                            };

                        }
                        return new()
                        {
                            isSuccedeed = false,
                            Message = ex.Message
                        };

                    }
            }
                return new()
                {isSuccedeed = false,
                    Message = "Silme İşlemi Başarısız"
                };
            }
            return new()
            {
                isSuccedeed = false,
                Message = "Kişi Bulunamadı"
            };
        }

        public async Task<GetAllProductResponse> GetAllProductAsync()
        {
            List<Product> products = await Table.ToListAsync();

            return new GetAllProductResponse()
            {
                products = products,

            };


        }

        public async Task<GetByIdProductResponse> GetByIdProductAsync(GetByIdProductRequest request)
        {
            List<Product> produts = await Table.ToListAsync();
            Product? product = produts.FirstOrDefault(data => data.Id.Equals(request.Id));
            if (product == null)
            {
                return GetByIdProductResponse.Failed(isFind: false, Message: "Ürün Bulunamadı");
            }
            else
            {
                return GetByIdProductResponse.Succedeed(isFind: true, product: product);

            }
        }

        public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {

            EntityEntry<Product> entity = Table.Update(new()
            {
                Id = request.Id,
                Ad = request.Ad,
                Adet = request.Adet,
                Fiyat = request.Fiyat,
            });

            try
            {
                await SaveChangesAsync();
                Product? product = Table.FirstOrDefault(data => data.Id.Equals(request.Id));
                return UpdateProductResponse.Succedeed(isSuccedeed: true, product: product);
            }
            catch (DbUpdateException ex)
            {
                return UpdateProductResponse.Failed(isSuccedeed: false, Message: ex.Message);

            }
        }
    }
}
