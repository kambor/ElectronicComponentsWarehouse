using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.DataAccess;
using Warehouse.DataAccess.Entities;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> GetProjectById([FromRoute] int projectId)
        {
            var request = new GetProjectByIdRequest()
            {
                ProjectId = projectId
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProject([FromBody] AddProjectRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{projectId}")]
        public async Task<IActionResult> DeleteProjectById([FromRoute] int projectId)
        {
            var request = new DeleteProjectByIdRequest()
            {
                ProjectId = projectId
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{projectId}")]
        public async Task<IActionResult> UpdateProjectById([FromRoute] int projectId, [FromBody] UpdateProjectByIdRequest request)
        {
            request.ProjectId = projectId;
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
