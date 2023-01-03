namespace Ecommerce.DataAccess.Entities.Auditing
{
    public interface IAuditableEntity : IHasCreatedDate, IHasDeletedDate, IHasUpdatedDate
    {

    }
}
