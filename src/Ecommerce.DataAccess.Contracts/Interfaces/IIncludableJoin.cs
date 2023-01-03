using System.Linq;

namespace Ecommerce.DataAccess.Interfaces
{
    public interface IIncludableJoin<out TEntity, out TProperty> : IQueryable<TEntity>
    {
    }
}
