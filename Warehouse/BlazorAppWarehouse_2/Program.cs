using BlazorAppWarehouse;
using BlazorAppWarehouse.Services.Authentications;
using BlazorAppWarehouse.Services.HttpServices;
using BlazorAppWarehouse.Services.LocalStorages;
using BlazorAppWarehouse.Services.Projects;
using BlazorAppWarehouse.Services.Users;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");


builder.Services
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IProjectService, ProjectService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();

// configure http client
builder.Services.AddScoped(x =>
{
    var apiurl = new Uri(builder.Configuration["apiurl"]);
    return new HttpClient() { BaseAddress = apiurl };
});

var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await host.RunAsync();
