using BlazorAppWarehouse;
using BlazorAppWarehouse.Services.Authentications;
using BlazorAppWarehouse.Services.HttpServices;
using BlazorAppWarehouse.Services.LocalStorages;
using BlazorAppWarehouse.Services.Projects;
using BlazorAppWarehouse.Services.Users;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(x =>
{
    var apiurl = new Uri(builder.Configuration["apiUrl"]);
    return new HttpClient() { BaseAddress = apiurl };
});

builder.Services
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IProjectService, ProjectService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();

//await builder.Build().RunAsync();
var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await host.RunAsync();
