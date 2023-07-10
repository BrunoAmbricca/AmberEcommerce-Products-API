using AmberEcommerce_Products_API.Model;
using Microsoft.EntityFrameworkCore;

namespace AmberEcommerce_Products_API.Contexts
{
    public class AmberEcommerceProductsContext : DbContext
    {
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CategoryProduct> CategoriesProducts { get; set; }

        public AmberEcommerceProductsContext(DbContextOptions<AmberEcommerceProductsContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("SqlDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasOne(c => c.ProductType)
            .WithMany(p => p.Categories)
            .HasForeignKey(c => c.ProductTypeId);

            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoriesProducts)
                .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CategoriesProducts)
                .HasForeignKey(cp => cp.ProductId);
        }
    }
}
