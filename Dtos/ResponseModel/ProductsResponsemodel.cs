namespace Backend.Dtos.ResponseModel
{
    public class ProductsResponsemodel : BaseResponse
    {
        public List<ProductDto> ProductDtos{get; set;} = new List<ProductDto>();
    }
}