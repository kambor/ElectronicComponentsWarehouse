using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using MediatR;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;

public class UpdateElectronicComponentByIRequest : IRequest<UpdateElectronicComponentByIResponse>
{
    public int ElectronicComponentId { get; set; }
    public string? Name { get; set; }

    public string? Manufacturer { get; set; }

    public string? StoreSymbol { get; set; }

    public Category? Category { get; set; }

    public double? Value { get; set; }

    public string? Unit { get; set; }

    public int? AvailableQuantity { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }
}
