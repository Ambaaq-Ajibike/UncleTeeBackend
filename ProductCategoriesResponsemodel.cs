namespace Backend.Dtos.ResponseModel
{
    public class ProductCategoriesResponsemodel : BaseResponse
    {
        public IReadOnlyList<ProductCategoryDto> ProductCategories {get; set;} = new List<ProductCategoryDto>();
    }
}