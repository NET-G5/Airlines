using Airline.Domain.Common;

namespace Airline.Domain.Entities;

public class Flight : EntityBase
{
    public string FlightNumber { get; set; }
    public int DepartureAirportID { get; set; }
    public int ArrivalAirportID { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public virtual Airport DepartureAirport { get; set; }
    public virtual Airport ArrivalAirport { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }

    public Flight()
    {
        Bookings = [];
    }
}