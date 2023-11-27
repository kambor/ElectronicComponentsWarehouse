using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.DataAccess;

public class QueryExecutor : IQueryExecutor
{
    private readonly WarehouseStorageContext _context;

    public QueryExecutor(WarehouseStorageContext context)
    {
        _context = context;
    }
    public Task<TResult> Execute<TResult>(QuerryBase<TResult> query)
    {
        return query.Execute(_context);
    }
}
