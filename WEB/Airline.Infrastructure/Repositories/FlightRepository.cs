using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
{
    public FlightRepository(AirlineDbContext context) : base(context) { }
    public List<Flight> GetAll(string where = "", string to = "", string departure = "", string numberOfAdults = "")
    {
        
        var query = _context.Flights
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .AsQueryable();

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

        string format = "dd/MM/yyyy";
        if (!string.IsNullOrWhiteSpace(departure))
        {
            if (DateTime.TryParseExact(departure, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
            {
                query = query.Where(x => x.DepartureTime.Date == dateTime.Date);
            }
        }

        if (!string.IsNullOrWhiteSpace(numberOfAdults) && int.TryParse(numberOfAdults, out int adults))
        {
            // query = query.Where(x => x.AvailableSeats >= adults);
        }



        return [.. query];
    }
    
    //private List<Flight> ConvertFlight(List<Flight> flights)
    //{
    //    var flightIds = flights.Select(f => f.ID).ToList();

    //    var allFlights = base._context.Flights
    //        .Where(f => flightIds.Contains(f.ID))
    //        .Include(f => f.DepartureAirport)
    //        .ThenInclude(a => a.Country)
    //        .Include(f => f.ArrivalAirport)
    //        .ThenInclude(a => a.Country)
    //        .Include(f => f.DepartureAirport)
    //        .ThenInclude(a => a.City)
    //        .Include(f => f.ArrivalAirport)
    //        .ThenInclude(a => a.City)
    //        .ToList();

    //    return allFlights;
    //}
}