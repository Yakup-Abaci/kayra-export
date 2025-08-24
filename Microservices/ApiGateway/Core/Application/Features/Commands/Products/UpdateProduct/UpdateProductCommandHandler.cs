using Application.Abstractions.Services.IProductService;
using Application.DTOs.UpdateProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;
        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateProductResponse response = await _productService.UpdateProductAsync(new()
            {
                Id = request.Id,
                Ad = request.Ad,
                Adet = request.Adet,
                Fiyat = request.Fiyat,
            });

            if (response.isSuccedeed)
            {
                return UpdateProductCommandResponse.Succedeed(isSuccedeed:response.isSuccedeed,product:response.product);
            }
            return UpdateProductCommandResponse.Failed(isSuccedeed: response.isSuccedeed, Message: response.Message);

        }
    }
}
