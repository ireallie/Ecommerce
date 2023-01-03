using System;

namespace Ecommerce.DataAccess.Entities.Auditing
{
    public interface IHasDeletedDate
    {
        DateTimeOffset? DeletedDate { get; set; }
    }
}
