using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class City : AuditableEntity
{
    public string CityName { get; set; }
    public int CountryID { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Airport> Airports { get; set; }
}