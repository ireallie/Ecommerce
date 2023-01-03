using Ecommerce.DataAccess.Entities.Products;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Contracts.Interfaces
{
    public interface IVariationService
    {
        Task<Variation> GetAsync(Expression<Func<Variation, bool>> expression);

        // var variation = await _unitOfWork.Variations.GetAsync(v => v.Name == variant.Name);
    }
}
