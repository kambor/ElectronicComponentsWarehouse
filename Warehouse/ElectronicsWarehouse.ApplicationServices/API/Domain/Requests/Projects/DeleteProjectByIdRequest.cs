using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;

public class DeleteProjectByIdRequest : IRequest<DeleteProjectByIdResponse>
{
    public int ProjectId { get; set; }
}
