using Ecommerce.DataAccess.Interfaces;
using Ecommerce.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }
        public IVariationRepository Variations { get; }
        public IVariationOptionRepository VariationOptions { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Products = new ProductRepository(_context);
            Variations = new VariationRepository(_context);
            VariationOptions = new VariationOptionRepository(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
