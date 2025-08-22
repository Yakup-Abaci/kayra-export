using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddProduct
{
    public class AddProductResponse
    {
        public bool isSuccedeed { get; set; }
        //public IQueryable<Product>? products { get; set; }
        //public string? token { get; set; }
        public string? Message { get; set; }
        //public int? ErrorCode { get; set; }

        public static AddProductResponse Succedeed(bool isSuccedeed,string Message)
        {
            return new AddProductResponse
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
        public static AddProductResponse Failed(bool isSuccedeed, string Message)
        {
            return new AddProductResponse
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }
    }
}
