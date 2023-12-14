using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries.Users;

public class GetUserQuery : QuerryBase<User>
{
    public string Username { get; set; }
    public override Task<User> Execute(WarehouseStorageContext context)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);
    }
}
