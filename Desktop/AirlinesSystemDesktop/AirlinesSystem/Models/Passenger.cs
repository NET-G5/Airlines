using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Passenger))]
public class Passenger
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
    public Gender GenderPassenger { get; set; }

    [Required]
    [StringLength(20)]
    public string PassportNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    public Passenger()
    {
        FirstName  = string.Empty; 
        LastName = string.Empty;
        PassportNumber = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
}
