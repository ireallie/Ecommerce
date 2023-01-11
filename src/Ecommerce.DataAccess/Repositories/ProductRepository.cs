using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) {}

        public override Task<IEnumerable<Product>> GetAllAsync()
        {
            // TODO: Include navigation entities (same as GetByIdAsync)
            return base.GetAllAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.ProductItems)
                .ThenInclude(p => p.ProductItemVariationOptions)
                .ThenInclude(p => p.VariationOption)
                .ThenInclude(p => p.Variation)
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();
        }
    }
}
