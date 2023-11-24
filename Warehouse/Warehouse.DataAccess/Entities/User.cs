using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public class User : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public string EmailAdress { get; set; }

    public List<Project> Projects { get; set; }
}
