namespace Ecommerce.Api.Dtos.Products.Base
{
    public class ProductEntityDto
        : ProductBaseDto
        , IEntityDto
    {
        public int Id { get; set; }
    }
}
