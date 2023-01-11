using Ecommerce.BusinessLogic.Communication.Products;
using Ecommerce.DataAccess.Entities.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Contracts.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<SaveProductResponse> CreateAsync(Product product);
        Task<SaveProductResponse> UpdateAsync(int id, Product product);
        Task<SaveProductResponse> DeleteAsync(int id);
    }
}
