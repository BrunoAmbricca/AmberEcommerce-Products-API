using AmberEcommerce_Products_API.Contexts;
using AmberEcommerce_Products_API.Interfaces.Repositories;
using AmberEcommerce_Products_API.Model;
using Microsoft.EntityFrameworkCore;

namespace AmberEcommerce_Products_API.Repositories
{
    public class ProductSqlRepository : IProductRepository
    {
        private readonly AmberEcommerceProductsContext _context;

        public ProductSqlRepository(AmberEcommerceProductsContext context)
        {
            _context = context;
        }

        public async Task<List<Product>?> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task InsertProduct(Product newProduct)
        {
            await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Products.AddAsync(newProduct);

                    await _context.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();

                    throw new Exception();
                }
            }
        }
    }
}
