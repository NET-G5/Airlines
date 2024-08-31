using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
{
    public FlightRepository(AirlineDbContext context) : base(context) { }

    public List<Flight> GetAll(string where = "", string to = "", string departure = "", string numberOfAdults = "")
    {
        using var context = new AirlineDbContext();

        var query = context.Flights.AsQueryable();

        if (!string.IsNullOrWhiteSpace(where))
        {
            var pattern = $"%{where}%";
            query = query.Where(x => EF.Functions.Like(x.DepartureAirport.Name, pattern));
            query = query.Where(x => EF.Functions.Like(x.DepartureAirport.City.CityName, pattern));
        }

        if (!string.IsNullOrWhiteSpace(to))
        {
            var pattern = $"%{to}%";
            query = query.Where(x => EF.Functions.Like(x.ArrivalAirport.Name, pattern));
            query = query.Where(x => EF.Functions.Like(x.ArrivalAirport.City.CityName, pattern));
        }

        if (!string.IsNullOrWhiteSpace(departure))
        {
            if (DateTime.TryParse(departure, out DateTime departureDate))
            {
                query = query.Where(x => x.DepartureTime.Date == departureDate.Date);
            }
        }

        if (!string.IsNullOrWhiteSpace(numberOfAdults) && int.TryParse(numberOfAdults, out int adults))
        {
            // query = query.Where(x => x.AvailableSeats >= adults);
        }


        string q = query.ToQueryString();
        
        var flights = query.AsNoTracking().ToList();

        return flights;
    }
    
    private List<Flight> ConvertFlight(List<Flight> flights)
    {
        var flightIds = flights.Select(f => f.ID).ToList();

        var allFlights = _context.Flights
            .Where(f => flightIds.Contains(f.ID))
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .ToList();

        return allFlights;
    }
}