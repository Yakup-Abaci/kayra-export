using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UpdateProduct
{
    public class UpdateProductResponse
    {
        public bool isSuccedeed { get; set; }
        public Product? product { get; set; }
        public string? Message { get; set; }

        public static UpdateProductResponse Succedeed(bool isSuccedeed,Product product)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                product = product
            };
        }
        public static UpdateProductResponse Failed(bool isSuccedeed, string Message) 
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
