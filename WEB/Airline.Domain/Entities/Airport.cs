using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Airport : EntityBase
{
    public string Name { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public virtual City City { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Flight> DepartureFlights { get; set; }
    public virtual ICollection<Flight> ArrivalFlights { get; set; }

    public Airport()
    {
        DepartureFlights = [];
        ArrivalFlights = [];
    }
}