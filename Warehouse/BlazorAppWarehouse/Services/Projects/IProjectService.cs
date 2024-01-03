namespace BlazorAppWarehouse.Services.Projects
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorAppWarehouse.Models;

    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProject();
        Task<Project> GetProjectById(int id);
        Task<Project> CreateProject(Project project);  
        Task<int> UpdateProject(Project project);
        Task<int> DeleteProject(int id);
    }
}