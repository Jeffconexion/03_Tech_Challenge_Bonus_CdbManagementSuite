using CdbBffSolution.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CdbBffSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCdbController : ControllerBase
    {
        private readonly IExternalProductServices _services;

        public ProductCdbController(IExternalProductServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomerProduct()
        {
            var response = await _services.GetAllAsync();
            return Ok(response);
        }
    }
}
