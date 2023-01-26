using Backend.Dtos;
using Backend.Dtos.ResponseModel;

namespace Backend.Interface.Services
{
    public interface IProductCategoryService
    {
        Task<BaseResponse> Add(ProductCategoryDto categoryDto);
        Task<BaseResponse> Delete(string name);
        Task<ProductCategoryResponsemodel> Get(string name);
        Task<ProductCategoriesResponsemodel> GetAll();
    }
}