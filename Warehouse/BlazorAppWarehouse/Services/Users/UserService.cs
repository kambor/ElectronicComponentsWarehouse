using BlazorAppWarehouse.Models;
using BlazorAppWarehouse.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppWarehouse.Services.Users
{
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<int> CreateUser(User user)
        {
            var result = await _httpService.Post<User>("/Users", user);
            return result.Id;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<User>>("/Users");
        }

        public async Task<User> GetMe()
        {
            return await _httpService.Get<User>("/Users/me");
        }
    }
}