
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.Users;

public class UpdateUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
