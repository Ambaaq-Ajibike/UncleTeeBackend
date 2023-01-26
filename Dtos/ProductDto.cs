namespace Backend.Dtos
{
    public class ProductDto
    {
        public string Name{get; set;}
        public string Image{get; set;}
        public decimal Price{get; set;}
        public int ProductCategoryId{get; set;}
        public string ProductCategoryName{get; set;}
    }
}