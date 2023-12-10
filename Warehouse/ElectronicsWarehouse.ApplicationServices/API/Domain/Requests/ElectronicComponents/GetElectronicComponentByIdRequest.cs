using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;

public class GetElectronicComponentByIdRequest : IRequest<GetElectronicComponentByIdResponse>
{
    public int ElectronicComponentId { get; set; }
}
