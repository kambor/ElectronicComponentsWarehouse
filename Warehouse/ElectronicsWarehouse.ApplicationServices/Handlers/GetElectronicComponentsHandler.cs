using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain;
using MediatR;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries;

namespace ElectronicsWarehouse.ApplicationServices.Handlers;

public class GetElectronicComponentsHandler : IRequestHandler<GetElectronicComonentRequest, GetElectronicComonentResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetElectronicComponentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }
    public async Task<GetElectronicComonentResponse> Handle(GetElectronicComonentRequest request, CancellationToken cancellationToken)
    {
        var query = new GetElectronicComponentsQuery();
        var electronicComponents = await _queryExecutor.Execute(query);
        var mappedElectronicComponent = _mapper.Map<List<API.Domain.Models.ElectronicComponent>>(electronicComponents);
        var response = new GetElectronicComonentResponse()
        {
            Data = mappedElectronicComponent
        };
        return response;
    }
}
