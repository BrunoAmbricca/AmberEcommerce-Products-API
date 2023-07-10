namespace AmberEcommerce_Products_API.Model
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<Category> Categories { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
    }
}
