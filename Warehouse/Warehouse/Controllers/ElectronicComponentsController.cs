using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsWarehouse.Controllers;

[ApiController]
[Route("[controller]")]
public class ElectronicComponentsController : ApiControllerBase
{
   

    public ElectronicComponentsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllElectronicComponents([FromQuery] GetElectronicComponentsRequest request)
    {
        return this.HandleRequest<GetElectronicComponentsRequest, GetElectronicComponentsResponse>(request);
    }

    [HttpGet]
    [Route("{electronicComponentId}")]
    public Task<IActionResult> GetById([FromRoute] int electronicComponentId)
    {
        var request = new GetElectronicComponentByIdRequest()
        {
            ElectronicComponentId = electronicComponentId
        };
        return this.HandleRequest<GetElectronicComponentByIdRequest, GetElectronicComponentByIdResponse>(request);
    }

}
