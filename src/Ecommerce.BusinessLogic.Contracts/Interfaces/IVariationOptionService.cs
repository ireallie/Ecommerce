using Ecommerce.DataAccess.Entities.Products;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Contracts.Interfaces
{
    public interface IVariationOptionService
    {
        Task<VariationOption> GetAsync(Expression<Func<VariationOption, bool>> expression);

        //var variationOption = await _unitOfWork.VariationOptions.GetAsync(v => v.Value == variant.Value);
    }
}
