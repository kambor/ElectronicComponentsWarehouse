using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.Users;

public class DeleteUserCommand : CommandBase<User,bool>
{
    public override async Task<bool> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.Remove(Parameter);
        await context.SaveChangesAsync();
        return true;
    }
}
