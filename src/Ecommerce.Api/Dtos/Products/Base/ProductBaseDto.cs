using System.Collections.Generic;

namespace Ecommerce.Api.Dtos.Products.Base
{
    public class ProductBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public string Label { get; set; }
        public bool IsActive { get; set; }
        public string SKU { get; set; }
        public int? Quantity { get; set; }

        public IList<ProductItemDto> ProductItems { get; set; } = new List<ProductItemDto>();
    }
}
