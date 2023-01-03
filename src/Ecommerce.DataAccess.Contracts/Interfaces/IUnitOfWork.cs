using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IVariationRepository Variations { get; }
        IVariationOptionRepository VariationOptions { get; }
        Task CompleteAsync();
    }
}
