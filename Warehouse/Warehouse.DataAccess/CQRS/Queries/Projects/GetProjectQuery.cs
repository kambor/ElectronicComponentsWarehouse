using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries.Projects;

public class GetProjectQuery : QuerryBase<Project>
{
    public int Id { get; set; }
    public override async Task<Project> Execute(WarehouseStorageContext context)
    {
        if (this.Id != null)
        {
            return await context.Projects.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
        else return null;
      
    }
}
