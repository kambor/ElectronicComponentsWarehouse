namespace BlazorAppWarehouse.Services.Authentications
{
    using System.Threading.Tasks;
    using BlazorAppWarehouse.Models;

    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}