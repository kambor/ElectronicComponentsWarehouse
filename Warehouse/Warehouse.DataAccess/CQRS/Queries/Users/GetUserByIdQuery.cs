using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries.Users;

public class GetUserByIdQuery : QuerryBase<User>
{
    public int Id { get; set; }
    public override Task<User> Execute(WarehouseStorageContext context)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
