namespace AmberEcommerce_Products_API.Model
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
    }
}
