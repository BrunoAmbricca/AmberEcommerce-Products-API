using AmberEcommerce_Products_API.Model;

namespace AmberEcommerce_Products_API.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetAllProducts();
        Task InsertProduct(Product newProduct);
    }
}
