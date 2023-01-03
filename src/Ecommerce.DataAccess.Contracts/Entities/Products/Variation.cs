using System.Collections.Generic;

namespace Ecommerce.DataAccess.Entities.Products
{
    public class Variation
    {
        public int VariationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VariationOption> VariationOptions { get; set; }
    }
}
