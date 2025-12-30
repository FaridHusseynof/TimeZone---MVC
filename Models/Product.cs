namespace TimeZone.Models
{
    public class Product : BaseModel
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public ICollection<ProductImage> productImages { get; set; }
    }
}
