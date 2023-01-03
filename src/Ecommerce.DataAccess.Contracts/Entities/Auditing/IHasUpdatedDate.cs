using System;

namespace Ecommerce.DataAccess.Entities.Auditing
{
    public interface IHasUpdatedDate
    {
        DateTimeOffset? UpdatedDate { get; set; }
    }
}
