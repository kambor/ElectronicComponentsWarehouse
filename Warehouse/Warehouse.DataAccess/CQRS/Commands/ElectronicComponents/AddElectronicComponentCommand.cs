using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.ElectronicCompoments;

public class AddElectronicComponentCommand : CommandBase<ElectronicComponent, ElectronicComponent>
{
    public override async Task<ElectronicComponent> Execute(WarehouseStorageContext context)
    {
        await context.ElectronicComponents.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
