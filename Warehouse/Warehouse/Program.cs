using ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;
using ElectronicsWarehouse.ApplicationServices.Mappings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess;
using Warehouse.DataAccess.CQRS;
using NLog.Web;
using Microsoft.AspNetCore.Authentication;
using MagazynEdu.Authentication;
using ElectronicsWarehouse.ApplicationServices.Components.Validators;
using Autofac.Core;
using ElectronicsWarehouse.ApplicationServices.Components.PasswordHasher;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddMvcCore().
    AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddProjectRequestValidator>());

//zachowanie API pozwala wejœæ do kontrolera w momencie wyst¹pienia b³êdu
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//AddTransient za ka¿dym razem kiedy jest wstrzykiwane tworzona jest nowa instancja
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExexutor, CommandExexutor>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

builder.Services.AddAutoMapper(typeof(ElectronicComponentsProfile).Assembly);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddDbContext<WarehouseStorageContext>(
    opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDatabaseConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
