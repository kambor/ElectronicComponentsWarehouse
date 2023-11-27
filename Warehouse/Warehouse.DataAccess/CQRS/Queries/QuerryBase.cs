namespace Warehouse.DataAccess.CQRS.Queries;

public abstract class QuerryBase<TResult>
{
    public abstract Task<TResult> Execute(WarehouseStorageContext context);
}
