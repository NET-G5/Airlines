using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class City : EntityBase
{
    public string CityName { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Airport> Airports { get; set; }

    public City()
    {
        Airports = [];
    }
}