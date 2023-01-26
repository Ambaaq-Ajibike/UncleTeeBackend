namespace Backend.Entities
{
    public class Product
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Image{get; set;}
        public decimal Price{get; set;}
        public int ProductCategoryId{get; set;}
        public ProductCategory ProductCategory{get; set;}
    }
}