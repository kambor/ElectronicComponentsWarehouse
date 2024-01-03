using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using System.Collections.Generic;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries.Projects;

namespace ElectronicsWarehouse.ApplicationServices.API.Handlers.Projects;

public class GetProjectsHandler : IRequestHandler<GetProjectsRequest, GetProjectsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProjectsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }
    public async Task<GetProjectsResponse> Handle(GetProjectsRequest request, CancellationToken cancellationToken)
    {
        var querry = new GetProjectsQuery();
        var projects = await _queryExecutor.Execute(querry);
        var mapedProjects = _mapper.Map<List<API.Domain.Models.Project>>(projects);
        return new GetProjectsResponse()
        {
            Data = mapedProjects
        };
    }
}
