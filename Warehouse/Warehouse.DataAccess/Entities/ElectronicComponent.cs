using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public class ElectronicComponent : EntityBase
{
    public List<Project> Projects { get; set; }
    public List<ShoppingList> ShoppingLists { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Manufacturer { get; set; }

    [Required]
    [MaxLength(100)]
    public string? StoreSymbol { get; set; }

    public Category? Category { get; set; }

    public double? Value { get; set; }

    public int? AvailableQuantity { get; set; }

    public double? Price { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}


public enum Category
{
    Resistor,
    Capacitor,
    Coil,
    IntegratedCircuit,
    Converter,
    Diode,
    Crystals
}
