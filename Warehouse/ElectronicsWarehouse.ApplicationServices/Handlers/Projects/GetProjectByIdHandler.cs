using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Models;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries.Projects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.Projects;

public class GetProjectbyIdHandler : IRequestHandler<GetProjectByIdRequest, GetProjectByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;
    public GetProjectbyIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetProjectByIdResponse> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProjectQuery()
        {
            Id = request.ProjectId
        };

        var getProject = await _queryExecutor.Execute(query);

        var mappedProject = _mapper.Map<Project>(getProject);

        return new GetProjectByIdResponse()
        {
            Data = mappedProject,
        };
    }
}
