using System;

namespace Ecommerce.DataAccess.Entities.Auditing
{
    public interface IHasCreatedDate
    {
        DateTimeOffset CreatedDate { get; set; }
    }
}
