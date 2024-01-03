using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Queries;

public class GetElectronicComponentsQuery : QuerryBase<List<ElectronicComponent>>
{
    public string Name { get; set; }
    public override Task<List<ElectronicComponent>> Execute(WarehouseStorageContext context)
    {       
        return context.ElectronicComponents.ToListAsync();       
    }
}
