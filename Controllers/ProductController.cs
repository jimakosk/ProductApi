using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
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
        private readonly IConfiguration configuration;

        public ProductController(IProductService productService,IConfiguration _config            )
        {
            _productService = productService;
            configuration = _config;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            if (products == null)
                return NotFound();
            
            return new JsonResult(products.First());
        }
        [HttpGet("GetCon")]
        public async Task<IActionResult> GetCon()
        {

            var test = configuration["ConnectionStrings"];
            var takis = configuration.GetSection("JwtOptions:Issuer");
            return Ok(takis);
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok("Server is up");
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product) 
        {

            return Ok();
        }
    }

}
