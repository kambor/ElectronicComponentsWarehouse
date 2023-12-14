using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.Projects;

public class AddProjectCommand : CommandBase<Project, Project>
{
    public override async Task<Project> Execute(WarehouseStorageContext context)
    {
        await context.Projects.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
