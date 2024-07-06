using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Employee))]
public class Employee
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    public Gender GenderEmployee { get; set; } 

    [Required]
    public int PositionID { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [ForeignKey("PositionID")]
    public virtual Position Position { get; set; }

    public Employee()
    {
        FirstName = string.Empty; 
        LastName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        Position = new Position();
    }
}

public enum Gender
{
    Male,
    Female
}