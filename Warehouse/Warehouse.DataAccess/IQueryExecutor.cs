using Warehouse.DataAccess.CQRS.Queries;

namespace Warehouse.DataAccess;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QuerryBase<TResult> query);
}
