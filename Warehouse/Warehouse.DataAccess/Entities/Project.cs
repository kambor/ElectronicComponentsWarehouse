using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public class Project : EntityBase
{
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public Status Status { get; set; }

    public List<ElectronicComponent> ElectronicComponents { get; set; }

    public double TotalCost { get; set; }

}

public enum Status
{
    InProgress,
    Completed,
    Suspended
}
