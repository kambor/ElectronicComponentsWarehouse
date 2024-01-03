using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Models;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;
using ElectronicsWarehouse.ApplicationServices.Components.PasswordHasher;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS;
using Warehouse.DataAccess.CQRS.Commands.Users;
using Warehouse.DataAccess.CQRS.Queries.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectronicsWarehouse.ApplicationServices.API.Handlers.Users;

public class ValidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IQueryExecutor _queryExecutor;

    public ValidateUserHandler(IMapper mapper, IPasswordHasher passwordHasher, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _queryExecutor = queryExecutor;
    }

    public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
    {

        var query = new GetUserByUsernameQuery()
        {
            Username = request.Username

        };

        var user = await _queryExecutor.Execute(query);

        if (user == null)
        {
            return new ValidateUserResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var password = _passwordHasher.HashToCheck(request.Password, user.Salt);
        if (user.Password != password)
        {
            return new ValidateUserResponse()
            {
                Error = new ErrorModel(ErrorType.ValidationError)
            };
        }

        var mappedUser = _mapper.Map<User>(user);

        return new ValidateUserResponse()
        {
            Data = mappedUser
        };
    }
}
