using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataAccess.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.Property(p => p.SKU)
                .HasMaxLength(12);

            builder.Property(p => p.ProductId)
                .IsRequired();
        }
    }
}
