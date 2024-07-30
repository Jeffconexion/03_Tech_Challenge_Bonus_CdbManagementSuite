using Microsoft.AspNetCore.Mvc;
using Product.Application.Dtos;
using Product.Application.IServices;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices productServices)
        {
            _services = productServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var response = await _services.Add(productDto);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetProduct()
        {
            var response = await _services.GetAll();
            return Ok(response);
        }

        [HttpGet("list-by-filter")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _services.GetById(id);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto, int id)
        {
            var record = await _services.GetById(id);

            if (record is null)
                return Ok("Não é possível autalizar, registro não existe!");

            var response = await _services.Update(productDto, id);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(int idProduct)
        {
            var response = await _services.Delete(idProduct);
            return Ok(response);
        }
    }
}
