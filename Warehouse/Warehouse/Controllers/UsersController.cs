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
   
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }

        [HttpDelete]
        [Route("{userId}")]
        public Task<IActionResult> DeleteUserById([FromRoute] int userId)
        {
            var request = new DeleteUserByIdRequest()
            {
                UserId = userId
            };
            return this.HandleRequest<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
        }

        [HttpPut]
        [Route("{userId}")]
        public Task<IActionResult> UpdateUserById([FromRoute] int userId, [FromBody] UpdateUserByIdRequest request)
        {
            request.UserId = userId;
            return this.HandleRequest<UpdateUserByIdRequest, UpdateUserByIdResponse>(request);
        }
    }
}
