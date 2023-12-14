using System.ComponentModel.DataAnnotations;

namespace Warehouse.DataAccess.Entities;

public class User : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    public string Salt { get; set; }

    public List<Project> Projects { get; set; }
}
