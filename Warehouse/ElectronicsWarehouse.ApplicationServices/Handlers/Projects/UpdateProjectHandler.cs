
using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries.Projects;
using Warehouse.DataAccess.CQRS.Commands;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.Projects;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectByIdRequest, UpdateProjectByIdResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;
    public UpdateProjectHandler(ICommandExexutor commandExexutor, IQueryExecutor queryExecutor, IMapper mapper)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<UpdateProjectByIdResponse> Handle(UpdateProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProjectQuery()
        {
            Id = request.ProjectId
        };
        var getProject = await _queryExecutor.Execute(query);

        if (getProject == null)
        {
            return new UpdateProjectByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedCommand = _mapper.Map<Warehouse.DataAccess.Entities.Project>(request);

        var command = new UpdateProjectCommand()
        {
            Parameter = mappedCommand
        };

        var projectFromDb = await _commandExexutor.Execute(command);

        return new UpdateProjectByIdResponse()
        {
            Data = _mapper.Map<API.Domain.Models.Project>(projectFromDb)
        };
    }
}
