using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using MediatR.Wrappers;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;

public class UpdateProjectByIdRequest : IRequest<UpdateProjectByIdResponse>
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public double TotalCost { get; set; }
    public int UserId { get; set; }
}
