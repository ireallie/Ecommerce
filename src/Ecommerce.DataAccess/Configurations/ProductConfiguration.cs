using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Label)
                .HasMaxLength(25);

            builder.Property(p => p.OldPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.RegularPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.SKU)
                .HasMaxLength(12);
        }
    }
}
