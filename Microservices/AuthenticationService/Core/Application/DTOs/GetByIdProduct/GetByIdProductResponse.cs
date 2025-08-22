using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GetByIdProduct
{
    public class GetByIdProductResponse
    {
        public bool isFind { get; set; }
        public Product? product { get; set; }
        public string? Message { get; set; }

        public static GetByIdProductResponse Succedeed(bool isFind,Product product)
        {
            return new()
            {
                isFind = isFind,
                product = product,
            };
        }

        public static GetByIdProductResponse Failed(bool isFind, string Message)
        {
            return new()
            {
                isFind = isFind,
                Message = Message,
            };
        }
    }
}
