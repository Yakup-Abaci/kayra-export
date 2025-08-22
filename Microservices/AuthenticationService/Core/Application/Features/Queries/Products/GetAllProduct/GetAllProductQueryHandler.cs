using Application.Abstractions.Services.IProductService;
using Application.DTOs.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductService _service;
        public GetAllProductQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllProductResponse reponse = await _service.GetAllProductAsync();

            return new()
            {
                products = reponse.products,
            };
            
        }
    }
}
