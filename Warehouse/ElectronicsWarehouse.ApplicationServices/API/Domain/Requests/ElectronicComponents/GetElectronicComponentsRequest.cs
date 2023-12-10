using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;

public class GetElectronicComponentsRequest : IRequest<GetElectronicComponentsResponse>
{
    public string Name { get; set; }
}
