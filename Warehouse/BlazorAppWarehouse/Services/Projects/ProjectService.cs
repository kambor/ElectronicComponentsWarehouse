using BlazorAppWarehouse.Models;
using BlazorAppWarehouse.Pages;
using BlazorAppWarehouse.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppWarehouse.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private IHttpService _httpService;

        public ProjectService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Project>> GetAllProject()
        {
            return await _httpService.Get<IEnumerable<Project>>("/projects");
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _httpService.Get<Project>($"/projects/{id}");
        }

        public async Task<Project> CreateProject(Project project)
        {
            var result = await _httpService.Post<Project>("/projects", project);
            return result;
        }

        public async Task<int> UpdateProject(Project project)
        {
            var result = await _httpService.Put<Project>($"/projects/{project.Id}", project);
            return result.Id;
        }

        public async Task<int> DeleteProject(int id)
        {
            await _httpService.Delete($"/projects/{id}");
            return id;
        }
    }
}