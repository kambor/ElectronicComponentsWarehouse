using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public class ShoppingList : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string ShopName { get; set; }

    public List<ElectronicComponent> ElectronicComponents { get; set; }
    public double TotalCost { get; set; }

}
