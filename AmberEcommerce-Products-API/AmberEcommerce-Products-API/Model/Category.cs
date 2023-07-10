namespace AmberEcommerce_Products_API.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
    }
}
