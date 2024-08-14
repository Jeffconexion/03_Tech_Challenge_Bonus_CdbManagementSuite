using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CdbBffSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCdbController : ControllerBase
    {
        private readonly IExternalCustomerServices _services;

        public CustomerCdbController(IExternalCustomerServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomerProduct()
        {
            var response = await _services.GetCustomer();
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            await _services.AddCustomer(customerDto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomer(int idCustomer)
        {
            await _services.DeleteCustomer(idCustomer);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto, int id)
        {
            await _services.UpdateCustomer(customerDto, id);
            return Ok();
        }
    }
}
