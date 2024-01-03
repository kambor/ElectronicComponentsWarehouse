using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;

public class DeleteElectronicComponentByIdRequest : IRequest<DeleteElectronicComponentByIdResponse>
{
    public int ElectronicComponentId { get; set; }
}
