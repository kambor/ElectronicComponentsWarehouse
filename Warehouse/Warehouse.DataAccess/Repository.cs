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
    public void Delete(int id)
    {
        T entity = _entities.SingleOrDefault(x => x.Id == id);
        _entities.Remove(entity);
        _context.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public T GetById(int id)
    {
        return _entities.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(T entity)
    {
        if(entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        
        _entities.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _context.SaveChanges();
    }
}
