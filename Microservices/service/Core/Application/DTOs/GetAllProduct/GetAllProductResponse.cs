using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GetAllProduct
{
    public class GetAllProductResponse
    {
        //public bool isSuccedeed { get; set; }
        //public string? token { get; set; }
        public List<Product>? products { get; set; }
        //public string? ErrorMessage { get; set; }
        //public int? ErrorCode { get; set; }
    }
}
