using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CdbBffSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdbBffController : ControllerBase
    {
        private readonly IProductClientServices _services;

        public CdbBffController(IProductClientServices services)
        {
            _services = services;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCustomerProduct([FromBody] ProductClientDto productClientDto)
        {
            var response = await _services.Add(productClientDto);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomerProduct()
        {
            var response = await _services.GetAll();
            return Ok(response);
        }

        [HttpGet("list-by-filter")]
        public async Task<IActionResult> GetCustomerProductById(int id)
        {
            var response = await _services.GetById(id);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomerProduct([FromBody] ProductClientDto productClientDto, int id)
        {
            var record = await _services.GetById(id);

            if (record is null)
                return Ok("Não é possível autalizar, registro não existe!");

            var response = await _services.Update(productClientDto, id);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomerProduct(int idCustomer)
        {
            var response = await _services.Delete(idCustomer);
            return Ok(response);
        }
    }
}
