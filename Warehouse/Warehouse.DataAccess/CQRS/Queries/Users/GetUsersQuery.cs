using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries.Users;

public class GetUsersQuery : QuerryBase<List<User>>
{
    public override Task<List<User>> Execute(WarehouseStorageContext context)
    {
        return context.Users.ToListAsync();
    }
}