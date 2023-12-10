using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.Mappings;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        this.CreateMap<AddProjectRequest, Project>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            .ForMember(x => x.TotalCost, y => y.MapFrom(z => z.TotalCost))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

        this.CreateMap<UpdateProjectByIdRequest, Project>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.ProjectId))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
           .ForMember(x => x.TotalCost, y => y.MapFrom(z => z.TotalCost))
           .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

        this.CreateMap<DeleteProjectByIdRequest, Project>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.ProjectId));

        this.CreateMap<Project, API.Domain.Models.Project>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
    }
}
