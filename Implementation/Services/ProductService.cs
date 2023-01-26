using Backend.Dtos;
using Backend.Dtos.ResponseModel;
using Backend.Entities;
using Backend.Interface.Repositories;
using Backend.Interface.Services;
using Mapster;

namespace Backend.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        public ProductService(IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository) => (_productRepository, _productCategoryRepository) = (productRepository, productCategoryRepository);
        public async Task<BaseResponse> Add(ProductDto productDto)
        {
            var exist = await _productRepository.Exist(x => x.Name.ToLower() == productDto.Name.ToLower());
            if(exist) return new BaseResponse{
                Status = false,
                Message = "category with this name already exist"
            };
            var getCategory = await _productCategoryRepository.Get(x => x.Name.ToLower() == productDto.ProductCategoryName.ToLower());
            if(getCategory == null) return new BaseResponse{
                Message = "Category selected for this product is not found",
                Status = false
            };
            productDto.ProductCategoryId = getCategory.Id;
            var product = productDto.Adapt<Product>();

            await _productRepository.Add(product);

            return new BaseResponse{
                Status = true,
                Message = "New product added successfully"
            };
        }

        public async Task<BaseResponse> Delete(string name)
        {
            var product = await _productRepository.Get(x => x.Name.ToLower() == name.ToLower());
            if(product == null) return new BaseResponse{
                Status = false,
                Message = "Product with this name doesn't exist"
            };
            await _productRepository.Delete(product);
            return new BaseResponse{
                Status = true,
                Message = "Product successfully deleted"
            };
        }

        public async Task<ProductResponsemodel> Get(string name)
        {
            var product = await _productRepository.Get(x => x.Name.ToLower() == name.ToLower());
            if(product == null) return new ProductResponsemodel{
                Status = false,
                Message = "Product with this name doesn't exist"
            };
            var productDto = product.Adapt<ProductDto>();
            return new ProductResponsemodel{
                Status = true,
                Message = $"{name} successfully retrieve",
                Data = productDto
            };
        }

        public async Task<ProductsResponsemodel> GetProductsByCategory(string categoryName)
        {
            var products = await _productRepository.GetAll(x => x.ProductCategory.Name == categoryName);
            if(products.Count == 0) return new ProductsResponsemodel{
                Status = false,
                Message = "The category doesn't contain any product"
            };
            var categoryDto = products.Adapt<List<ProductDto>>();
            return new ProductsResponsemodel{
                Status = true,
                Message = $"List of products",
                ProductDtos = categoryDto
            };
        }
    }
}