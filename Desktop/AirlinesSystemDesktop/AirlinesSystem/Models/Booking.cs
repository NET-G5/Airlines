using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Booking))]
public class Booking
{
    [Key]
    public int ID { get; set; }

    [Required]
    public int FlightID { get; set; }

    [Required]
    public int PassengerID { get; set; }

    [StringLength(5)]
    public string SeatNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BookingDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(20)]
    public BookingStatus Status { get; set; }

    public Booking()
    {
        SeatNumber = string.Empty;
    }
}
public enum BookingStatus
{
    Confirmed,
    Pending,
    Cancelled
}