using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries;

public class GetElectronicComponentsQuery : QuerryBase<List<ElectronicComponent>>
{
    public string Name { get; set; }
    public override Task<List<ElectronicComponent>> Execute(WarehouseStorageContext context)
    {
        if(this.Name != null)
        {
            return context.ElectronicComponents.Where(x => x.Name == this.Name).ToListAsync();
        }
        else
        {
            return context.ElectronicComponents.ToListAsync();
        }
    }
}
