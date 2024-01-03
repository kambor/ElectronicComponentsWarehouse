namespace BlazorAppWarehouse.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorAppWarehouse.Models;

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<int> CreateUser(User user);
        Task<User> GetMe();
    }
}