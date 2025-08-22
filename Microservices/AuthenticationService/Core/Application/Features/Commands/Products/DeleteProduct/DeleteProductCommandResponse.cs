using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public bool isSuccedeed { get; set; }
        public string Message { get; set; }
    }
}
