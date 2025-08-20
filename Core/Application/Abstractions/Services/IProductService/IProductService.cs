using Application.DTOs.AddProduct;
using Application.DTOs.DeleteProduct;
using Application.DTOs.GetAllProduct;
using Application.DTOs.GetByIdProduct;
using Application.DTOs.UpdateProduct;
using Application.Features.Commands.Products.AddProduct;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.IProductService
{
    public interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest request);

        Task<GetAllProductResponse> GetAllProductAsync();
        Task<GetByIdProductResponse> GetByIdProductAsync(GetByIdProductRequest request);
        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);
        Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request);
    }
}
