using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Passenger))]
public class Passenger
{
    [Key]
    public long PassengerID { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [StringLength(20)]
    public string PassportNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    public ICollection<Booking> Bookings { get; set; }

    public Passenger()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
        Bookings = new List<Booking>();
        PassportNumber = string.Empty;
    }
}
