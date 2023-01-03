using System.Collections.Generic;

namespace Ecommerce.Api.Dtos.Products.Base
{
    public class ProductItemDto
    {
        public string SKU { get; set; } 
        public int? Quantity { get; set; }

        public IList<VariationDto> Variations { get; set; } = new List<VariationDto>();
    }
}
