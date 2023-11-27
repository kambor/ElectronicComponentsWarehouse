using Warehouse.DataAccess.CQRS.Commands;

namespace Warehouse.DataAccess.CQRS;

public class CommandExexutor : ICommandExexutor
{
    private readonly WarehouseStorageContext _context;

    public CommandExexutor(WarehouseStorageContext context)
    {
        _context = context;
    }
    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(_context);
    }
}
