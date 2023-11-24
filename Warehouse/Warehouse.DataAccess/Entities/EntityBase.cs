using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}
