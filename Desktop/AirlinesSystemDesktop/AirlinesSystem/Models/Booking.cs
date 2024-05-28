using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AirlinesSystem.Models;

[Table(nameof(Booking))]
public class Booking
{
    [Key]
    public long BookingID { get; set; }
    [Required]
    public long FlightID { get; set; }
    [Required]
    public long PassengerID { get; set; }
    [StringLength(5)]
    public string SeatNumber { get; set; } 
    public DateTime BookingDate { get; set; } 
    [StringLength(20)]
    public string BookingStatus { get; set; } 


    [ForeignKey("FlightID")]
    public Flight Flight { get; set; }
    [ForeignKey("PassengerID")]
    public Passenger Passenger { get; set; }

    public Booking()
    {
        SeatNumber = string.Empty;
        BookingDate = DateTime.Now;
        BookingStatus = "Confirmed";
        Flight = new Flight();
        Passenger = new Passenger();
    }
}
