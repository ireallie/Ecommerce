using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;

namespace Ecommerce.DataAccess.Repositories
{
    public class VariationRepository : RepositoryBase<Variation>, IVariationRepository
    {
        public VariationRepository(ApplicationDbContext context) : base(context) { }
    }
}
