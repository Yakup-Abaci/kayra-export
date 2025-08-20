using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
    }
}
