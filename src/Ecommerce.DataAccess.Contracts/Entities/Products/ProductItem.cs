using System.Collections.Generic;

namespace Ecommerce.DataAccess.Entities.Products
{
    public class ProductItem
    {
        public int ProductItemId { get; set; }
        public string SKU { get; set; }
        public int? Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<ProductItemVariationOption> ProductItemVariationOptions { get; set; }      
    }
}
