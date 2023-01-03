using Ecommerce.DataAccess.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace Ecommerce.DataAccess.Entities.Products
{
    public class Product : IAuditableEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public string Label { get; set; }
        public bool IsActive { get; set; }
        public string SKU { get; set; }
        public int? Quantity { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public virtual ICollection<ProductItem> ProductItems { get; set; }
    }
}
