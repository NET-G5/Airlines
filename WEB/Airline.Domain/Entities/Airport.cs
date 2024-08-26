using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Airport : AuditableEntity
{
    public string Name { get; set; }
    public int CityID { get; set; }
    public int CountryID { get; set; }
    public virtual City City { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Flight> DepartureFlights { get; set; }
    public virtual ICollection<Flight> ArrivalFlights { get; set; }
}