namespace Backend.Entities
{
    public class ProductCategory
    {
        public int Id{get; set;}
        public string Name{get; set;}
        List<Product> Products{get; set;} = new List<Product>();
    }
}