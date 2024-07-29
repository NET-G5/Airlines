namespace Airline.Domain.Entities;

public class Country
{
    public int ID { get; set; }
    public string CountryName { get; set; }
    public virtual ICollection<City> Cities { get; set; }
    public virtual ICollection<Airport> Airports { get; set; }
}