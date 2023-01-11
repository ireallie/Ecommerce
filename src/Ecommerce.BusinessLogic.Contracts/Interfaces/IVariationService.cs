using Ecommerce.DataAccess.Entities.Products;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Contracts.Interfaces
{
    public interface IVariationService
    {
        Task<Variation> GetAsync(Expression<Func<Variation, bool>> expression);
    }
}
