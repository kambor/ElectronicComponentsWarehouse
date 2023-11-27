using Warehouse.DataAccess.CQRS.Commands;

namespace Warehouse.DataAccess.CQRS;

public interface ICommandExexutor
{
    Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
}
