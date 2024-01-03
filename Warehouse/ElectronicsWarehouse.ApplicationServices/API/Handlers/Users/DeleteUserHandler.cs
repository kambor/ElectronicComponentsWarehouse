using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS.Queries.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.CQRS.Commands.Users;

namespace ElectronicsWarehouse.ApplicationServices.API.Handlers.Users;

public class DeleteUserHandler : IRequestHandler<DeleteUserByIdRequest, DeleteUserByIdResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;

    public DeleteUserHandler(ICommandExexutor commandExexutor, IQueryExecutor queryExecutor, IMapper mapper)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteUserByIdResponse> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery()
        {
            Id = request.UserId
        };

        var getUser = await _queryExecutor.Execute(query);

        if (getUser == null)
        {
            return new DeleteUserByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedCommand = _mapper.Map<Warehouse.DataAccess.Entities.User>(request);

        var command = new DeleteUserCommand()
        {
            Parameter = mappedCommand
        };

        var userFromDb = await _commandExexutor.Execute(command);

        return new DeleteUserByIdResponse()
        {
            Data = userFromDb
        };
    }
}
