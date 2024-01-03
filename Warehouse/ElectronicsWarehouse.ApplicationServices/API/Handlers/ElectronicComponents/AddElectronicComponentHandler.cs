using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands.ElectronicCompoments;
using Warehouse.DataAccess.Entities;
using Warehouse.DataAccess.Migrations;

namespace ElectronicsWarehouse.ApplicationServices.API.Handlers.ElectronicComponents;

public class AddElectronicComponentHandler : IRequestHandler<AddElectronicComponentRequest, AddElectronicComponentResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IMapper _mapper;

    public AddElectronicComponentHandler(IMapper mapper, ICommandExexutor commandExexutor)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
    }

    public async Task<AddElectronicComponentResponse> Handle(AddElectronicComponentRequest request, CancellationToken cancellationToken)
    {
        var electronicComponent = _mapper.Map<ElectronicComponent>(request);
        var command = new AddElectronicComponentCommand() { Parameter = electronicComponent };
        var electronicComponentFromDb = await _commandExexutor.Execute(command);
        return new AddElectronicComponentResponse()
        {
            Data = _mapper.Map<API.Domain.Models.ElectronicComponent>(electronicComponentFromDb)
        };
    }
}
