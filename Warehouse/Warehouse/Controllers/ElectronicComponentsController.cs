using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.ElectronicComponents;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsWarehouse.Controllers;

[Authorize]
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

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddElectronicComponent([FromBody] AddElectronicComponentRequest request)
    {
        return this.HandleRequest<AddElectronicComponentRequest, AddElectronicComponentResponse>(request);
    }

    [HttpDelete]
    [Route("{electronicComponentId}")]
    public Task<IActionResult> DeleteElectronicComponentById([FromRoute] int electronicComponentId)
    {
        var request = new DeleteElectronicComponentByIdRequest()
        {
            ElectronicComponentId = electronicComponentId
        };

        return this.HandleRequest<DeleteElectronicComponentByIdRequest, DeleteElectronicComponentByIdResponse>(request);
    }

    [HttpPut]
    [Route("{electronicComponentId}")]
    public Task<IActionResult> UpdateElectronicComponentById([FromRoute] int electronicComponentId, [FromBody] UpdateElectronicComponentByIRequest request)
    {
        request.ElectronicComponentId = electronicComponentId;
        return this.HandleRequest<UpdateElectronicComponentByIRequest, UpdateElectronicComponentByIResponse>(request);
    }

}
