using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.Users;

public class AddUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(WarehouseStorageContext context)
    {
        await context.Users.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
