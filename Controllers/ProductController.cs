using Microsoft.AspNetCore.Mvc;
using ProductApi.Servises;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProductApi.Controllers
{   

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null)
                return NotFound();
            
            return Ok(products);
        }
    }

}
