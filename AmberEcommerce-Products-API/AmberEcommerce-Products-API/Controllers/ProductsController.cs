using AmberEcommerce_Products_API.Contexts;
using AmberEcommerce_Products_API.Interfaces.Repositories;
using AmberEcommerce_Products_API.Model;
using AmberEcommerce_Products_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmberEcommerce_Products_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> GetAllProducts()
        {
            return new OkObjectResult(await _productRepository.GetAllProducts());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert(Product newProduct)
        {
            try
            {
                newProduct.Path = newProduct.Name.Replace(" ", "-");
                newProduct.Created = DateTime.UtcNow;

                await _productRepository.InsertProduct(newProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
