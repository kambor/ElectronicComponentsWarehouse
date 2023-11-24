using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Warehouse.DataAccess;

public class WarehouseStorageContextFactory : IDesignTimeDbContextFactory<WarehouseStorageContext>
{
    public WarehouseStorageContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WarehouseStorageContext>();
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseStorage;Integrated Security=True;TrustServerCertificate=True");
        return new WarehouseStorageContext(optionsBuilder.Options);
    }
}
