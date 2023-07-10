using System.Reflection.Metadata.Ecma335;

namespace AmberEcommerce_Products_API.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public ICollection<CategoryProduct> CategoriesProducts { get; set; } = new List<CategoryProduct>();
        public DateTime Created { get; set; }
        //public DateTime Updated { get; set; }
        public DateTime Deleted { get; set; }
    }
}
