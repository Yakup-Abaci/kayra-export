using Application.Abstractions.Services.IProductService;
using Application.DTOs.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductService _productService;
        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteProductResponse response = await _productService.DeleteProductAsync(request: new()
            {
                Id = request.Id
            }
            );

            return new()
            {
                isSuccedeed = response.isSuccedeed,
                Message = response.Message
            };

            

        }
    }
}
