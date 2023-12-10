using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands;

public class AddProjectCommand : CommandBase<Project, Project>
{
    public override async Task<Project> Execute(WarehouseStorageContext context)
    {
        await context.Projects.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
