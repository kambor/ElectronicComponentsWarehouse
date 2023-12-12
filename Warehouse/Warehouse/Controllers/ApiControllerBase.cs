using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElectronicsWarehouse.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    private readonly IMediator _mediator;
    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse :ErrorResponseBase
    {
        if(!this.ModelState.IsValid)
        {
            return this.BadRequest(
                this.ModelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new { property = x.Key, errors = x.Value.Errors}));
        }

        var response = await _mediator.Send(request);
        if(response.Error != null)
        {
            return this.ErrorResponse(response.Error);
        }

        return this.Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        return StatusCode((int)httpCode, errorModel);
    }

    private static HttpStatusCode GetHttpStatusCode(string errorType)
    {
        switch (errorType)
        {
            case ErrorType.NotFound:
                return HttpStatusCode.NotFound;
            case ErrorType.InternalServerError:
                return HttpStatusCode.InternalServerError;
            case ErrorType.Unauthorized:
                return HttpStatusCode.Unauthorized;
            case ErrorType.RequestTooLarge:
                return HttpStatusCode.RequestEntityTooLarge;
            case ErrorType.UnsupportedMethod:
                return HttpStatusCode.MethodNotAllowed;
            case ErrorType.UnsupportedMiediaType:
                return HttpStatusCode.UnsupportedMediaType;
            case ErrorType.TooManyRequests:
                return HttpStatusCode.TooManyRequests;
            default:
                return HttpStatusCode.BadRequest;
        }
    }
}
