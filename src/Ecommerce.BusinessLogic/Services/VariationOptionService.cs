using Ecommerce.BusinessLogic.Contracts.Interfaces;
using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Services
{
    public class VariationOptionService : IVariationOptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VariationOptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }    

        public async Task<VariationOption> GetAsync(Expression<Func<VariationOption, bool>> expression)
        {
            return await _unitOfWork.VariationOptions.GetAsync(expression);
        }
    }
}
