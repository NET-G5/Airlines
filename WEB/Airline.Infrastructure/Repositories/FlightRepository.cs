using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
{
    public FlightRepository(AirlineDbContext context) : base(context) { }
    
    public List<Flight> GetAll(string where = "", string to = "", string departure = "", string numberOfAdults = "")
    {
        var query = GetFlightQuery();

        if (!string.IsNullOrWhiteSpace(where))
        {
            var pattern = $"%{where}%";
            query = query.Where(x => EF.Functions.Like(x.DepartureAirport.Country.CountryName, pattern));
            query = query.Where(x => EF.Functions.Like(x.DepartureAirport.City.CityName, pattern));
        }

        if (!string.IsNullOrWhiteSpace(to))
        {
            var pattern = $"%{to}%";
            query = query.Where(x => EF.Functions.Like(x.ArrivalAirport.Country.CountryName, pattern));
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

        var flights = query.ToList();
        
        return flights;
    }

    public Flight GetByIdFlight(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }
    
    private Flight GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = GetFlightQuery().AsNoTracking().FirstOrDefault(x => x.Id == id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(Flight)} with id:{id} is not found");
        }

        return entity;
    }

    private IQueryable<Flight> GetFlightQuery()
    {
        return _context.Flights
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .AsQueryable();
    }
}