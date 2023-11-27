using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries;

public class GetElectronicComponentQuery : QuerryBase<ElectronicComponent>
{
    public int Id { get; set; }
    public override async Task<ElectronicComponent> Execute(WarehouseStorageContext context)
    {
        var electronicComponent = await context.ElectronicComponents.FirstOrDefaultAsync(x => x.Id == this.Id);
        return electronicComponent;
    }
}
