using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.CQRS.Commands.ElectronicComponents;

public class DeleteElectronicComponentCommand : CommandBase<ElectronicComponent, bool>
{
    public async override Task<bool> Execute(WarehouseStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.ElectronicComponents.Remove(Parameter);
        await context.SaveChangesAsync();
        return true;
    }
}
