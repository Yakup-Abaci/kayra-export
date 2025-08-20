using Application.Features.Commands.Products.AddProduct;
using Application.Features.Commands.Products.DeleteProduct;
using Application.Features.Commands.Products.UpdateProduct;
using Application.Features.Queries.Products.GetAllProduct;
using Application.Features.Queries.Products.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KayraExportAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllProduct")]
        public async Task<IActionResult> GetAllProducts()
        {
            GetAllProductQueryRequest request = new GetAllProductQueryRequest();
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetByIdProduct/{id:int}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] int id)
        {
            GetByIdProductQueryRequest request = new GetByIdProductQueryRequest();
            request.Id = id;
            GetByIdProductQueryResponse response =  await _mediator.Send(request);
            if (response.isFind)
            {
                return Ok(response.product);
            }
            return NotFound(response.Message);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest request)
        {
            AddProductCommandResponse response =  await _mediator.Send(request);

            if (response.isSuccedeed)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest update_product)
        {
            
            UpdateProductCommandResponse response = await _mediator.Send(update_product);
            if(response.isSuccedeed)
            {
                return Ok(response.product); 
            }
            return BadRequest(response.Message);

            
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete([FromBody]DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response =  await _mediator.Send(request);

            if(response.isSuccedeed)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
            
        }
    }
}
