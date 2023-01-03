using Ecommerce.DataAccess.Entities.Products;

namespace Ecommerce.BusinessLogic.Communication.Products
{
    public class SaveProductResponse : BaseResponse
    {
        public Product Product { get; private set; }

        private SaveProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="product">Saved product.</param>
        /// <returns>Response.</returns>
        public SaveProductResponse(Product product) : this(true, string.Empty, product)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveProductResponse(string message) : this(false, message, null)
        { }
    }
}
