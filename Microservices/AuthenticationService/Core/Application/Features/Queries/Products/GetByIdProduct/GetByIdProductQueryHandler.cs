using Application.Abstractions.Services.IProductService;
using Application.DTOs.GetByIdProduct;
using Google.Apis.Upload;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductService _productService;
        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdProductResponse response =  await _productService.GetByIdProductAsync(new()
            {
                Id = request.Id,
            });

            if (response.isFind)
            {
                return GetByIdProductQueryResponse.Succedeed(isFind:response.isFind, product: response.product);
            }
            return GetByIdProductQueryResponse.Failed(isFind: response.isFind, Message: response.Message);
            
        }
    }
}
