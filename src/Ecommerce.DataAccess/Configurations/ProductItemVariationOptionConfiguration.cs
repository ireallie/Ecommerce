using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataAccess.Configurations
{
    public class ProductItemVariationOptionConfiguration : IEntityTypeConfiguration<ProductItemVariationOption>
    {
        public void Configure(EntityTypeBuilder<ProductItemVariationOption> builder)
        {
            builder.HasKey(p => new { p.ProductItemId, p.VariationOptionId });
            builder.HasIndex(p => new { p.ProductItemId, p.VariationOptionId });

            builder.HasOne(p => p.ProductItem)
                    .WithMany(o => o.ProductItemVariationOptions)
                    .HasForeignKey(p => p.ProductItemId);

            builder.HasOne(p => p.VariationOption)
                    .WithMany(o => o.ProductItemVariationOptions)
                    .HasForeignKey(p => p.VariationOptionId);

            builder.Property(p => p.ProductItemId)
                .IsRequired();

            builder.Property(p => p.VariationOptionId)
                .IsRequired();
        }
    }
}
