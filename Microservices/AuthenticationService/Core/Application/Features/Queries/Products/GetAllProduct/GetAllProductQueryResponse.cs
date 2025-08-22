using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        //public bool isSuccedeed { get; set; }
        public List<Product>? products { get; set; }
    }

    /*public class GetAllProductSuccedeedQueryResponse
    {
        public IQueryable<Product>? products { get; set; }
    }

    public class GetAllProductFailedQueryResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }*/

}
