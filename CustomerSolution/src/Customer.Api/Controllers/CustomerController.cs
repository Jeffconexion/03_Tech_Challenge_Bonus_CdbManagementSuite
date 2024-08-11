using Customer.Application.Dtos;
using Customer.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;

        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customerDto)
        {
            var response = await _services.Add(customerDto);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomer()
        {
            var response = await _services.GetAll();
            return Ok(response);
        }

        [HttpGet("list-by-filter")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await _services.GetById(id);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto, int id)
        {
            var record = await _services.GetById(id);

            if (record is null)
                return Ok("Não é possível autalizar, registro não existe!");

            var response = await _services.Update(customerDto, id);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomer(int idCustomer)
        {
            var response = await _services.Delete(idCustomer);
            return Ok(response);
        }
    }
}
