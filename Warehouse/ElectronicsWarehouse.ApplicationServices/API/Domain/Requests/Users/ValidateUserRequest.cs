using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;

public class ValidateUserRequest : IRequest<ValidateUserResponse>
{
    public string Username { get; set; }

    public string Password { get; set; }
}
