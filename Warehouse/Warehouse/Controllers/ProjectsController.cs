using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses.Projects;
using ElectronicsWarehouse.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.DataAccess;
using Warehouse.DataAccess.Entities;

namespace Warehouse.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ApiControllerBase
    {
        public ProjectsController(IMediator mediator, ILogger<ProjectsController> logger) : base(mediator) 
        {
            logger.LogInformation("We are in Projects");
        }

        [HttpGet]
        [Route("{projectId}")]
        public Task<IActionResult> GetProjectById([FromRoute] int projectId)
        {
            var request = new GetProjectByIdRequest()
            {
                ProjectId = projectId
            };

            return this.HandleRequest<GetProjectByIdRequest, GetProjectByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProject([FromBody] AddProjectRequest request)
        {
            return this.HandleRequest<AddProjectRequest, AddProjectResponse>(request);
        }

        [HttpDelete]
        [Route("{projectId}")]
        public Task<IActionResult> DeleteProjectById([FromRoute] int projectId)
        {
            var request = new DeleteProjectByIdRequest()
            {
                ProjectId = projectId
            };
            return this.HandleRequest<DeleteProjectByIdRequest, DeleteProjectByIdResponse>(request);
        }

        [HttpPut]
        [Route("{projectId}")]
        public Task<IActionResult> UpdateProjectById([FromRoute] int projectId, [FromBody] UpdateProjectByIdRequest request)
        {
            request.ProjectId = projectId;
            return this.HandleRequest<UpdateProjectByIdRequest, UpdateProjectByIdResponse>(request);
        }
    }
}
