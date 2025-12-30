namespace TimeZone.Models
{
    public class Category:BaseModel
    {
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
