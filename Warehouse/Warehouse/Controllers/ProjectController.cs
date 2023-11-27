using Microsoft.AspNetCore.Mvc;
using Warehouse.DataAccess;
using Warehouse.DataAccess.Entities;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        //[HttpGet]
        //[Route("")]
        //public IEnumerable<Project> GetAllProjects() => _projectRepository.GetAll();

        //[HttpGet]
        //[Route("{projectId}")]
        //public Project GetProjectById(int projectId) => _projectRepository.GetById(projectId);
    }
}
