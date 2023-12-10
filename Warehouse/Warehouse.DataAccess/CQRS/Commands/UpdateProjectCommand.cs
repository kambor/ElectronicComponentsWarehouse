using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands;

public class UpdateProjectCommand : CommandBase<Project, Project>
{
    public override async Task<Project> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Projects.Update(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}