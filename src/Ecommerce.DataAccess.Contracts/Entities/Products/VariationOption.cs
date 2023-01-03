using System.Collections.Generic;

namespace Ecommerce.DataAccess.Entities.Products
{
    public class VariationOption
    {
        public int VariationOptionId { get; set; }
        public string Value { get; set; } 

        public int VariationId { get; set; }
        public virtual Variation Variation { get; set; }

        public virtual ICollection<ProductItemVariationOption> ProductItemVariationOptions { get; set; }
    }
}
