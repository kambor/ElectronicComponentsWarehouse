using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess;

public class WarehouseStorageContext: DbContext
{
    public WarehouseStorageContext(DbContextOptions<WarehouseStorageContext> opt) : base(opt)
    {
        
    }

    public DbSet<ElectronicComponent> ElectronicComponents { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }

}
