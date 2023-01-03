using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;

namespace Ecommerce.DataAccess.Repositories
{
    public class VariationOptionRepository : RepositoryBase<VariationOption>, IVariationOptionRepository
    {
        public VariationOptionRepository(ApplicationDbContext context) : base(context) { }
    }
}
