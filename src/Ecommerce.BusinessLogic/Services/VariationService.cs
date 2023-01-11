using Ecommerce.BusinessLogic.Contracts.Interfaces;
using Ecommerce.DataAccess.Entities.Products;
using Ecommerce.DataAccess.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Services
{
    public class VariationService : IVariationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VariationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Variation> GetAsync(Expression<Func<Variation, bool>> expression)
        {      
            return await _unitOfWork.Variations.GetAsync(expression);
        }
    }
}
