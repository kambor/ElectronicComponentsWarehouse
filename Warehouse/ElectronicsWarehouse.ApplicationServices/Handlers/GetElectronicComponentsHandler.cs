using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain;
using MediatR;
using Warehouse.DataAccess;

namespace ElectronicsWarehouse.ApplicationServices.Handlers;

public class GetElectronicComponentsHandler : IRequestHandler<GetElectronicComonentRequest, GetElectronicComonentResponse>
{
    private readonly IRepository<Warehouse.DataAccess.Entities.ElectronicComponent> _electronicComponentRepository;
    private readonly IMapper _mapper;

    public GetElectronicComponentsHandler(IRepository<Warehouse.DataAccess.Entities.ElectronicComponent> electronicComponentRepository, IMapper mapper)
    {
        _electronicComponentRepository = electronicComponentRepository;
        _mapper = mapper;
    }
    public Task<GetElectronicComonentResponse> Handle(GetElectronicComonentRequest request, CancellationToken cancellationToken)
    {
        var electronicComponent = _electronicComponentRepository.GetAll();
        var mappedElectronicComponent = _mapper.Map<List<API.Domain.Models.ElectronicComponent>>(electronicComponent);
        var response = new GetElectronicComonentResponse()
        {
            Data = mappedElectronicComponent
        };
        return Task.FromResult(response);
    }
}
