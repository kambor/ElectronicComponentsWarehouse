using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries;
using Warehouse.DataAccess.CQRS.Queries.Users;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.Users;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;
    public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery();
        var users = await _queryExecutor.Execute(query);
        var mappedUsers = _mapper.Map<List<API.Domain.Models.User>>(users);
        var response = new GetUsersResponse()
        {
            Data = mappedUsers
        };
        return response;
    }
}
