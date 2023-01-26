using Backend.Dtos;
using Backend.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => (_productService) = (productService);
        [HttpPost("product/add")]
        public async Task<IActionResult> AddProduct(ProductDto ProductDto)
        {
            var product = await _productService.Add(ProductDto);
            return (product.Status) ? Ok(product) : BadRequest(product);
        }
        [HttpGet("product/get/{productName}")]
        public async Task<IActionResult> GetProduct(string productName)
        {
            var product = await _productService.Get(productName);
            return (product.Status) ? Ok(product) : BadRequest(product);
        }
        [HttpGet("products/all/{category}")]
        public async Task<IActionResult> GetAllProducts(string category)
        {
            var product = await _productService.GetProductsByCategory(category);
            return (product.Status) ? Ok(product) : BadRequest(product);
        }
        [HttpDelete("product/delete/{name}")]
        public async Task<IActionResult> DeleteProduct(string name)
        {
            var product = await _productService.Delete(name);
            return (product.Status) ? Ok(product) : BadRequest(product);
        }
    }
}