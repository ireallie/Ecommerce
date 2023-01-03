using Ecommerce.DataAccess.Entities.Auditing;
using Ecommerce.DataAccess.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Ecommerce.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "t-shirt the hate",
                    Description = @"T-shirt the hate,100 cotton, machine embroidery, oversized fit.
                                so much hate for me everywhere today, can't figure out what i did to cause it... i am trying to ovrercome, to overcome it all.",
                    RegularPrice = 3000,
                    Label = "preorder",
                    IsActive = true,
                    CreatedDate = DateTimeOffset.UtcNow,
                }
            );

            modelBuilder.Entity<ProductItem>().HasData(
                new ProductItem
                {
                    ProductItemId = 1,
                    SKU = "HATE-000-S-M",
                    Quantity = 50,
                    ProductId = 1
                },
                new ProductItem
                {
                    ProductItemId = 2,
                    SKU = "HATE-000-M-L",
                    Quantity = 50,
                    ProductId = 1
                },
                new ProductItem
                {
                    ProductItemId = 3,
                    SKU = "HATE-000-XL+",
                    Quantity = 50,
                    ProductId = 1
                },
                new ProductItem
                {
                    ProductItemId = 4,
                    SKU = "HATE-FFF-S-M",
                    Quantity = 50,
                    ProductId = 1
                },
                new ProductItem
                {
                    ProductItemId = 5,
                    SKU = "HATE-FFF-M-L",
                    Quantity = 50,
                    ProductId = 1
                },
                new ProductItem
                {
                    ProductItemId = 6,
                    SKU = "HATE-FFF-XL+",
                    Quantity = 50,
                    ProductId = 1,
                }
            );

            modelBuilder.Entity<Variation>().HasData(
                new Variation()
                {
                    VariationId = 1,
                    Name = "Color",
                },
                new Variation()
                {
                    VariationId = 2,
                    Name = "Size"
                }
            );

            modelBuilder.Entity<VariationOption>().HasData(
                new VariationOption
                {
                    VariationOptionId = 1,
                    VariationId = 1,
                    Value = "White"
                },
                new VariationOption
                {
                    VariationOptionId = 2,
                    VariationId = 1,
                    Value = "Black",
                },
                new VariationOption
                {
                    VariationOptionId = 3,
                    VariationId = 2,
                    Value = "S-M",
                },
                new VariationOption
                {
                    VariationOptionId = 4,
                    VariationId = 2,
                    Value = "M-L",
                },
                new VariationOption
                {
                    VariationOptionId = 5,
                    VariationId = 2,
                    Value = "XL+",
                }
            );

            modelBuilder.Entity<ProductItemVariationOption>().HasData(
                new ProductItemVariationOption
                {
                    ProductItemId = 1,
                    VariationOptionId = 2,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 1,
                    VariationOptionId = 3
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 2,
                    VariationOptionId = 2,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 2,
                    VariationOptionId = 4,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 3,
                    VariationOptionId = 2,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 3,
                    VariationOptionId = 5,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 4,
                    VariationOptionId = 1,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 4,
                    VariationOptionId = 3,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 5,
                    VariationOptionId = 1,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 5,
                    VariationOptionId = 4,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 6,
                    VariationOptionId = 1,
                },
                new ProductItemVariationOption
                {
                    ProductItemId = 6,
                    VariationOptionId = 5,
                }
            );
        }

        public static void HandleSoftDeletes(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IHasDeletedDate).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var deletedCheck = Expression.Lambda(Expression.Equal(Expression.Property(parameter, "DeletedDate"), Expression.Constant(null)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(deletedCheck);
                }
            }
        }
    }
}
