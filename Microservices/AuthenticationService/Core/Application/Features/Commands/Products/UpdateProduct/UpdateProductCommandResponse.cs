using Application.DTOs.UpdateProduct;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public bool isSuccedeed { get; set; }
        public Product? product { get; set; }
        public string? Message { get; set; }

        public static UpdateProductCommandResponse Succedeed(bool isSuccedeed, Product product)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                product = product
            };
        }
        public static UpdateProductCommandResponse Failed(bool isSuccedeed, string Message)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
