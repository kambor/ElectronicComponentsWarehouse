using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.Projects;

public class AddProjectHandler : IRequestHandler<AddProjectRequest, AddProjectResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IMapper _mapper;

    public AddProjectHandler(ICommandExexutor commandExexutor, IMapper mapper)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
    }

    public async Task<AddProjectResponse> Handle(AddProjectRequest request, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<Project>(request);
        var command = new AddProjectCommand() { Parameter = project };
        var projectFromDb = await _commandExexutor.Execute(command);
        return new AddProjectResponse()
        {
            Data = _mapper.Map<API.Domain.Models.Project>(projectFromDb)
        };
    }
}
