using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AddProduct
{
    public class AddProductRequest
    {
        public string Ad { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
    }
}
