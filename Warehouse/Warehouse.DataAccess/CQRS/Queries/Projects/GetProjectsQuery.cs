using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries.Projects;

public class GetProjectsQuery : QuerryBase<List<Project>>
{
    public int Id { get; set; }
    public override Task<List<Project>> Execute(WarehouseStorageContext context)
    {
        return context.Projects
            .Include(x => x.ElectronicComponents)
            .ToListAsync();

    }
}
