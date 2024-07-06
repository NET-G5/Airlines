using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Flight))]
public class Flight
{
    [Key]
    public int ID { get; set; }

    [Required]
    public int AircraftID { get; set; }

    [Required]
    public int FromID { get; set; }

    [Required]
    public int ToID { get; set; }

    [Required]
    public FlightStatus FlightStatus { get; set; } // Изменили тип данных

    [ForeignKey("AircraftID")]
    public virtual Aircraft Aircraft { get; set; }

    [ForeignKey("FromID")]
    public virtual From From { get; set; }

    [ForeignKey("ToID")]
    public virtual To To { get; set; }

    public Flight()
    {
        Aircraft = new Aircraft();
        To = new To();
        From = new From();
    }
}
public enum FlightStatus
{
    Scheduled,
    Cancelled,
    Delayed
}
