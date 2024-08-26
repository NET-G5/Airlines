using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Country : AuditableEntity
{
    public string CountryName { get; set; }
    public virtual ICollection<City> Cities { get; set; }
    public virtual ICollection<Airport> Airports { get; set; }
}