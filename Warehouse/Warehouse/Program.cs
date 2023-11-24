using ElectronicsWarehouse.ApplicationServices.API.Domain;
using ElectronicsWarehouse.ApplicationServices.Mappings;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
