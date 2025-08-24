using Application.Abstractions.Services.IProductService;
using Application.DTOs.AddProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductService _productService;
        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            AddProductResponse response =  await _productService.AddProductAsync(new()
            {
                Ad = request.Ad,
                Fiyat = request.Fiyat,
                Adet = request.Adet
            });

            if(response.isSuccedeed)
            {
                return AddProductCommandResponse.Succedeed(isSuccedeed:response.isSuccedeed, Message:response.Message);
                
            }
            return AddProductCommandResponse.Succedeed(isSuccedeed: response.isSuccedeed, Message: response.Message);
        }
    }
}
