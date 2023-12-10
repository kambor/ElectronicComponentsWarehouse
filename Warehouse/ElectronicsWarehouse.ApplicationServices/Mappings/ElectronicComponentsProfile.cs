using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Models;

namespace ElectronicsWarehouse.ApplicationServices.Mappings;

public class ElectronicComponentsProfile : Profile
{
    public ElectronicComponentsProfile()
    {
        this.CreateMap<Warehouse.DataAccess.Entities.ElectronicComponent, ElectronicComponent>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
    }
}