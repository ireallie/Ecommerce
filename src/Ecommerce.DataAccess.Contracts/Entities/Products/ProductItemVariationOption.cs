namespace Ecommerce.DataAccess.Entities.Products
{
    public class ProductItemVariationOption
    {
        public int ProductItemId { get; set; }
        public virtual ProductItem ProductItem { get; set; }

        public int VariationOptionId { get; set; }
        public virtual VariationOption VariationOption { get; set; }
    }
}
