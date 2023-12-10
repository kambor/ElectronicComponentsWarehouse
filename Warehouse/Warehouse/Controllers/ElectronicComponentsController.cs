using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.ElectronicComponents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsWarehouse.Controllers;

[ApiController]
[Route("[controller]")]
public class ElectronicComponentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ElectronicComponentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllElectronicComponents([FromQuery] GetElectronicComponentsRequest request)
    {
        var response = await _mediator.Send(request);
        return this.Ok(response);
    }

    [HttpGet]
    [Route("{electronicComponentId}")]
    public async Task<IActionResult> GetById([FromRoute] int electronicComponentId)
    {
        var request = new GetElectronicComponentByIdRequest()
        {
            ElectronicComponentId = electronicComponentId
        };

        var response = await _mediator.Send(request);
        return this.Ok(response);
    }

}
