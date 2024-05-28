using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(FlightCrew))]
public class FlightCrew
{
    [Key] 
    public long FlightID { get; set; }
    public long CrewID { get; set; }
    public AssignmentRole AssignmentRole { get; set; }

    [ForeignKey("FlightID")]
    public Flight Flight { get; set; }
    [ForeignKey("CrewID")]
    public Crew Crew { get; set; }

    public FlightCrew()
    {
        Flight = new Flight();
        Crew = new Crew();
    }
}

public enum AssignmentRole
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
