using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public bool isFind { get; set; }
        public Product? product { get; set; }
        public string Message { get; set; }


        public static GetByIdProductQueryResponse Succedeed(bool isFind,Product product)
        {
            return new() { isFind = isFind,product = product };
        }

        public static GetByIdProductQueryResponse Failed(bool isFind, string Message)
        {
            return new() { isFind = isFind,Message = Message };
        }
    }

   
}
