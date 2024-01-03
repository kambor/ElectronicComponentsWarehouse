using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.ElectronicComponents;

public class UpdateElectronicComponentCommand : CommandBase<ElectronicComponent, ElectronicComponent>
{
    public async override Task<ElectronicComponent> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.ElectronicComponents.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
