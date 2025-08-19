using KayraExportAPI.Contretes.ProductContretes;
using KayraExportAPI.Modals;
using Microsoft.AspNetCore.Mvc;

namespace KayraExportAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductReadConcretes _readproduct;
        private readonly ProductWriteConcretes _writeproduct;

        public ProductController(ProductWriteConcretes writeproduct, ProductReadConcretes readproduct)
        {
            _writeproduct = writeproduct;
            _readproduct = readproduct;
        }

        [HttpGet("AllProduct")]
        public IActionResult GetAllProducts()
        {
            var all_product = _readproduct.GetAllProduct();
            return Ok(all_product);
        }

        [HttpGet("GetByIdProduct/{id:int}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var product = await _readproduct.GetByIdProductAsync(id);
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModal product)
        {
            var result = await _writeproduct.AddProductAsync(product);
            if (result)
            {
                await _writeproduct.SaveCahngesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest("Ürün Eklenmedi");
            }
            
        }

        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductModal product)
        {
            var result = await _writeproduct.UpdateProduct(id,product);
            if (result)
            {
                await _writeproduct.SaveCahngesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest("Ürün Eklenmedi");
            }
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _writeproduct.DeleteProductAsync(id);
            if (result)
            {
                await _writeproduct.SaveCahngesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest("Ürün Eklenmedi");
            }
        }
    }
}
