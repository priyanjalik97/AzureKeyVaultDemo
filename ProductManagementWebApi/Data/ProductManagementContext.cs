using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Data
{
    public class ProductManagementContext : DbContext
    {

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductWarehouseStock> ProductWarehouseStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(t => t.Price).IsRequired();
            
        }
    }
}
