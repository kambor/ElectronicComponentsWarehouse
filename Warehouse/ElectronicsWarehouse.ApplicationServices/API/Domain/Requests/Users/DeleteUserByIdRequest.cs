using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;

public class DeleteUserByIdRequest : IRequest<DeleteUserByIdResponse>
{
    public int UserId { get; set; }
}

