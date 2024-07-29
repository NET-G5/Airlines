namespace Airline.Domain.Entities;

public class Airport
{
    public int ID { get; set; }
    public string AirportName { get; set; }
    public int CityID { get; set; }
    public int CountryID { get; set; }
    public virtual City City { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Flight> DepartureFlights { get; set; }
    public virtual ICollection<Flight> ArrivalFlights { get; set; }
}