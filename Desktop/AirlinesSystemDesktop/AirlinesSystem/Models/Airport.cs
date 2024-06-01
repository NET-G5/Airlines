using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Airport))]
public class Airport
{
    [Key]
    public long AirportID { get; set; }
    [Required]
    [StringLength(10)]
    public string AirportCode { get; set; } 
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(50)]
    public string City { get; set; }
    [Required]
    [StringLength(50)]
    public string Country { get; set; }

    public ICollection<Flight> OriginFlights { get; set; }
    public ICollection<Flight> DestinationFlights { get; set; }

    public Airport() 
    {
        AirportCode = string.Empty;
        Name = string.Empty;
        City = string.Empty;
        Country = string.Empty;
        DestinationFlights = new HashSet<Flight>();
        OriginFlights = new HashSet<Flight>();
        DestinationFlights = new HashSet<Flight>();
    }
}
