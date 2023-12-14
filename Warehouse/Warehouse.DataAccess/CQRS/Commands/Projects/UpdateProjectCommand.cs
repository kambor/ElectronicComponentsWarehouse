using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.Projects;

public class UpdateProjectCommand : CommandBase<Project, Project>
{
    public override async Task<Project> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Projects.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}