using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Crew))]
public class Crew
{
    [Key]
    public long CrewID { get; set; }
    [Required, StringLength(50)]
    public string FirstName { get; set; }
    [Required, StringLength(50)]
    public string LastName { get; set; }
    public CrewRole Role { get; set; }

    public ICollection<FlightCrew> FlightCrews { get; set; }

    public Crew()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        FlightCrews = new List<FlightCrew>();
    }
}

public enum CrewRole
{
    Pilot,              // Пилот
    CoPilot,            // Второй пилот
    FlightAttendant,    // Бортпроводник
    LeadFlightAttendant,// Старший бортпроводник
    Navigator,          // Штурман
    FlightEngineer,     // Бортинженер
    Purser,             // Супервайзер экипажа
    LoadMaster,         // Специалист по загрузке
    Mechanic            // Механик
}
