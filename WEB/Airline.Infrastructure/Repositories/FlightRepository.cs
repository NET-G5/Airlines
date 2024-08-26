using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
{
    public FlightRepository(AirlineDbContext context) : base(context) { }

    public List<Flight> GetAll(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetAll();
        }

        var flights = _context.Flights
            .Where(x => x.FlightNumber == search
            || x.ArrivalAirportID == int.Parse(search)
            || x.DepartureAirportID == int.Parse(search)
            || x.Price == decimal.Parse(search)).ToList();

        return flights;
    }
}