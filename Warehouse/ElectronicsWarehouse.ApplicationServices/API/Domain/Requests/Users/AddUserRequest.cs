using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;

public class AddUserRequest : IRequest<AddUserResponse>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Salt { get; set; }
}
