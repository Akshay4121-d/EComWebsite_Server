using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStaticWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _IProductRepository; 
        public ProductController(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _IProductRepository.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("getProductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _IProductRepository.GetProductAsync(id);
            return Ok(product);
        }
        [HttpPost("AddProduct")]

        public async Task<ActionResult<productModel>> AddProduct(productModel product)
        {
            productModel product1= await _IProductRepository.AddProductAsync(product);
            return Ok(product1);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<productModel>> UpdateProduct(int id , productModel product)
        {
            await _IProductRepository.UpdateProductAsync(id, product);  
            return Ok(product);
        }
        [HttpDelete]
        public async Task<ActionResult> deleteProduct(int id)
        {
           return (ActionResult)await _IProductRepository.DeleteProductAsync(id);
        }
    }
}
