using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Aircraft))]
public  class Aircraft
{
    [Key]
    public long AircraftID { get; set; }
    [Required, StringLength(10)]
    public string TailNumber { get; set; } 
    [Required, StringLength(50)]
    public string Model { get; set; } 
    [Required, StringLength(50)]
    public string Manufacturer { get; set; } 
    [Required]
    public int SeatingCapacity { get; set; }

    public ICollection<Flight> Flights { get; set; }

    public Aircraft() 
    {
        TailNumber = string.Empty;
        Model = string.Empty;
        Manufacturer = string.Empty;
        SeatingCapacity = 0;
        Flights = new List<Flight>();
    }
}
