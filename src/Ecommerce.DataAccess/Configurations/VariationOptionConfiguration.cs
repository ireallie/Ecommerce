using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataAccess.Configurations
{
    public class VariationOptionConfiguration : IEntityTypeConfiguration<VariationOption>
    {
        public void Configure(EntityTypeBuilder<VariationOption> builder)
        {
            builder.Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.VariationId)
                .IsRequired();

            builder
                .HasIndex(v => v.Value)
                .IsUnique();
        }
    }
}
