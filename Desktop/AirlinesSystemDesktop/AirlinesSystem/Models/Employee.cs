using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Employee))]
public class Employee
{
    [Key]
    public long EmployeeID { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [StringLength(50)]
    public string Position { get; set; } = string.Empty;
    [Required]
    public DateTime HireDate { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    [Required]
    public long AccessLevelID { get; set; }

    [ForeignKey("AccessLevelID")]
    public AccessLevel AccessLevel { get; set; }


    public Employee()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
        AccessLevel = new AccessLevel();
    }
}
