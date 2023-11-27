using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly WarehouseStorageContext _context;
    private DbSet<T> _entities;

    public Repository(WarehouseStorageContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }
    public async Task Delete(int id)
    {
        T entity = await _entities.SingleOrDefaultAsync(x => x.Id == id);
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<List<T>> GetAll()
    {
        return _entities.ToListAsync();
    }

    public Task<T> GetById(int id)
    {
        return _entities.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task Insert(T entity)
    {
        if(entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        
        _entities.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        return _context.SaveChangesAsync();
    }
}
