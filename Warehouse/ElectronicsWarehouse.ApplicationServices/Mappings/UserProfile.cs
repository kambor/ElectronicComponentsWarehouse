using AutoMapper;
using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Users;
using Warehouse.DataAccess.Entities;

namespace ElectronicsWarehouse.ApplicationServices.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        this.CreateMap<User, API.Domain.Models.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

        this.CreateMap<AddUserRequest, User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
            .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));
    }
}
