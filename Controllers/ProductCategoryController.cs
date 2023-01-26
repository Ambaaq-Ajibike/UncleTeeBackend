using Backend.Dtos;
using Backend.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService) => (_productCategoryService) = (productCategoryService);
        [HttpPost("productCategory/add")]
        public async Task<IActionResult> AddProductCategory(ProductCategoryDto ProductCategoryDto)
        {
            var productCategory = await _productCategoryService.Add(ProductCategoryDto);
            return (productCategory.Status) ? Ok(productCategory) : BadRequest(productCategory);
        }
        [HttpGet("productCategory/get/{productCategoryName}")]
        public async Task<IActionResult> GetProductCategory(string productCategoryName)
        {
            var productCategory = await _productCategoryService.Get(productCategoryName);
            return (productCategory.Status) ? Ok(productCategory) : BadRequest(productCategory);
        }
        [HttpGet("productCategorys/all")]
        public async Task<IActionResult> GetAllProductCategorys()
        {
            var productCategory = await _productCategoryService.GetAll();
            return (productCategory.Status) ? Ok(productCategory) : BadRequest(productCategory);
        }
        [HttpDelete("productCategory/delete/{name}")]
        public async Task<IActionResult> DeleteProductCategory(string name)
        {
            var productCategory = await _productCategoryService.Delete(name);
            return (productCategory.Status) ? Ok(productCategory) : BadRequest(productCategory);
        }
    }
}