using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Flight))]
public class Flight
{
    [Key]
    public long FlightID { get; set; }
    [Required]
    [StringLength(10)]
    public string FlightNumber { get; set; }
    [Required]
    public long AircraftID { get; set; }
    [Required]
    public long OriginAirportID { get; set; }
    [Required]
    public long DestinationAirportID { get; set; }
    [Required]
    public DateTime DepartureTime { get; set; }
    [Required]
    public DateTime ArrivalTime { get; set; }
    public FlightStatus Status { get; set; } = FlightStatus.Scheduled;

    [ForeignKey("AircraftID")]
    public Aircraft Aircraft { get; set; }
    [ForeignKey("OriginAirportID")]
    public Airport OriginAirport { get; set; }
    [ForeignKey("DestinationAirportID")]
    public Airport DestinationAirport { get; set; }

    public ICollection<Booking> Bookings { get; set; }
    public ICollection<FlightCrew> FlightCrews { get; set; }

    public Flight()
    {
        FlightNumber = string.Empty;
        Aircraft = new Aircraft();
        OriginAirport = new Airport();
        DestinationAirport = new Airport();
        Bookings = new List<Booking>();
        FlightCrews = new List<FlightCrew>();
    }
}

public enum FlightStatus
{
    Scheduled,
    Cancelled,
    Delayed
}
