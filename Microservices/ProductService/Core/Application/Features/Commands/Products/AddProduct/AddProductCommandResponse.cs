using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandResponse
    {
        public bool isSuccedeed { get; set; }
        public string Message { get; set; }

        public static AddProductCommandResponse Succedeed(bool isSuccedeed,string Message)
        {
            return new()
            {
                isSuccedeed = isSuccedeed,
                Message = Message
            };
        }

        public static AddProductCommandResponse Failed(bool isSuccedeed,string Message)
        {
            return new()
            {
                Message = Message
            };
        }
    }

}
