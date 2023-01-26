using Backend.Dtos;
using Backend.Dtos.ResponseModel;
using Backend.Entities;
using Backend.Interface.Repositories;
using Backend.Interface.Services;
using Mapster;

namespace Backend.Implementation.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _productCategory;
        public ProductCategoryService(IRepository<ProductCategory> productCategory) => (_productCategory) = (productCategory);
        public async Task<BaseResponse> Add(ProductCategoryDto categoryDto)
        {
            var exist = await _productCategory.Exist(x => x.Name.ToLower() == categoryDto.Name.ToLower());
            if(exist) return new BaseResponse{
                Status = false,
                Message = "Category with this name already exist"
            };

            var category = categoryDto.Adapt<ProductCategory>();

            await _productCategory.Add(category);

            return new BaseResponse{
                Status = true,
                Message = "New category added successfully"
            };
        }

        public async Task<BaseResponse> Delete(string name)
        {
            var category = await _productCategory.Get(x => x.Name.ToLower() == name.ToLower());
            if(category == null) return new BaseResponse{
                Status = false,
                Message = "Category with this name doesn't exist"
            };
            await _productCategory.Delete(category);
            return new BaseResponse{
                Status = true,
                Message = "Category successfully deleted"
            };
        }

        public async Task<ProductCategoryResponsemodel> Get(string name)
        {
            var category = await _productCategory.Get(x => x.Name.ToLower() == name.ToLower());
            if(category == null) return new ProductCategoryResponsemodel{
                Status = false,
                Message = "Category with this name doesn't exist"
            };
            var categoryDto = category.Adapt<ProductCategoryDto>();
            return new ProductCategoryResponsemodel{
                Status = true,
                Message = $"{name} successfully retrieve",
                Data = categoryDto
            };
        }

        public async Task<ProductCategoriesResponsemodel> GetAll()
        {
            var categories = await _productCategory.GetAll(x => true);
            if(categories.Count == 0) return new ProductCategoriesResponsemodel{
                Status = false,
                Message = "Category with this name doesn't exist"
            };
            var categoryDto = categories.Adapt<List<ProductCategoryDto>>();
            return new ProductCategoriesResponsemodel{
                Status = true,
                Message = $"List of Categorys",
                ProductCategories = categoryDto
            };
        }
    }
}