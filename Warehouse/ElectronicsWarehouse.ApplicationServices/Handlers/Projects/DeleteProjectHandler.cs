using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Models;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;
using MediatR;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.CQRS.Queries.Projects;


namespace ElectronicsWarehouse.ApplicationServices.Handlers.Projects;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectByIdRequest, DeleteProjectByIdResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;
    public DeleteProjectHandler(ICommandExexutor commandExexutor, IQueryExecutor queryExecutor, IMapper mapper)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteProjectByIdResponse> Handle(DeleteProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProjectQuery()
        {
            Id = request.ProjectId
        };
        var getProject = await _queryExecutor.Execute(query);

        if (getProject == null)
        {
            return new DeleteProjectByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedCommand = _mapper.Map<Warehouse.DataAccess.Entities.Project>(request);

        var command = new DeleteProjectCommand() 
        {
            Parameter = mappedCommand
        };
        var projectFromDb = await _commandExexutor.Execute(command);
        return new DeleteProjectByIdResponse()
        {
            Data = projectFromDb
        };
    }
}
