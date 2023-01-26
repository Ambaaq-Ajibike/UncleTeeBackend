using Backend.Dtos;
using Backend.Dtos.ResponseModel;

namespace Backend.Interface.Services
{
    public interface IProductService
    {
        Task<BaseResponse> Add(ProductDto product);
        Task<BaseResponse> Delete(string name);
        Task<ProductResponsemodel> Get(string name);
        Task<ProductsResponsemodel> GetProductsByCategory(string categoryName);
    }
}