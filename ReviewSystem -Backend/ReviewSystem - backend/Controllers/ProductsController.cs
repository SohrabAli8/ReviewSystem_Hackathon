using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ReviewSystem.Interfaces;

namespace ReviewSystem.Controllers
{
    [Route("api/products")]
    [ApiController]
    [AllowAnonymous]   // Public access
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}