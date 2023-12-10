using AutoMapper;
using MediatR;
using Warehouse.DataAccess.CQRS.Queries;
using Warehouse.DataAccess;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.ElectronicComponents;

public class GetElectronicComponentByIdHandler : IRequestHandler<GetElectronicComponentByIdRequest, GetElectronicComponentByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetElectronicComponentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }
    public async Task<GetElectronicComponentByIdResponse> Handle(GetElectronicComponentByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetElectronicComponentQuery()
        {
            Id = request.ElectronicComponentId
        };
        var electronicComponent = await _queryExecutor.Execute(query);
        var mappedElectronicComponent = _mapper.Map<API.Domain.Models.ElectronicComponent>(electronicComponent);
        var response = new GetElectronicComponentByIdResponse()
        {
            Data = mappedElectronicComponent
        };
        return response;
    }
}

