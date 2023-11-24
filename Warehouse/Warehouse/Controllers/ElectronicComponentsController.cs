using ElectronicsWarehouse.ApplicationServices.API.Domain;
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
    public async Task<IActionResult> GetAllBooks([FromQuery] GetElectronicComonentRequest request)
    {
        var response = await _mediator.Send(request);
        return this.Ok(response);
    }
    
}
