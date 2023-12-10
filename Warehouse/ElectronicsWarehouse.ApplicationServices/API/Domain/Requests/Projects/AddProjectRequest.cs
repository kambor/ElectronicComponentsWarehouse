using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;

public class AddProjectRequest : IRequest<AddProjectResponse>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public double TotalCost { get; set; }
    public int UserId { get; set; }
}
