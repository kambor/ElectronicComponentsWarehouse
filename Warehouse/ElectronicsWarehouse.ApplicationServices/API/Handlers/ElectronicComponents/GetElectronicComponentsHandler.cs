using AutoMapper;
using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using MediatR;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.ElectronicComponents;

public class GetElectronicComponentsHandler : IRequestHandler<GetElectronicComponentsRequest, GetElectronicComponentsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetElectronicComponentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }
    public async Task<GetElectronicComponentsResponse> Handle(GetElectronicComponentsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetElectronicComponentsQuery()
        {
            Name = request.Name
        };
        var electronicComponents = await _queryExecutor.Execute(query);
        var mappedElectronicComponent = _mapper.Map<List<API.Domain.Models.ElectronicComponent>>(electronicComponents);
        var response = new GetElectronicComponentsResponse()
        {
            Data = mappedElectronicComponent
        };
        return response;
    }
}

