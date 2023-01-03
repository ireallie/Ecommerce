using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataAccess.Configurations
{
    public class VariationConfiguration : IEntityTypeConfiguration<Variation>
    {
        public void Configure(EntityTypeBuilder<Variation> builder)
        {
            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasIndex(v => v.Name)
                .IsUnique();
        }
    }
}
