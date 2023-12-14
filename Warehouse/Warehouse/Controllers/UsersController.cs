using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsWarehouse.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {           
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {         
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}
