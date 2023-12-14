using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands;

public class DeleteProjectCommand : CommandBase<Project, bool>
{
    public override async Task<bool> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Projects.Remove(Parameter);
        await context.SaveChangesAsync();
        return true;
    }
}
