using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using ElectronicsWarehouse.ApplicationServices.Components.PasswordHasher;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands.Users;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.Handlers.Users;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly ICommandExexutor _commandExexutor;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public AddUserHandler(ICommandExexutor commandExexutor, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _commandExexutor = commandExexutor;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var auth = _passwordHasher.Hash(request.Password);
        request.Password = auth[0];
        request.Salt = auth[1];

        var user = _mapper.Map<User>(request);
        var command = new AddUserCommand() 
        { 
            Parameter = user 
        };
        var userFromDb = await _commandExexutor.Execute(command);
        return new AddUserResponse()
        { 
            Data = _mapper.Map<API.Domain.Models.User>(userFromDb)
        };         
    }
}
