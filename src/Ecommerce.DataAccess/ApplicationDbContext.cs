using Ecommerce.DataAccess.Configurations;
using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItemVariationOption> ProductItemsVariationOptions { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<VariationOption> VariationOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.Seed();
            modelBuilder.HandleSoftDeletes();

            base.OnModelCreating(modelBuilder);
        }
    }
}
