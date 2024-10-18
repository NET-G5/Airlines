using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
{
    public BookingRepository(AirlineDbContext context) : base(context) { }
    
    public List<Booking> GetAll(int userId, string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetBookingQuery().ToList();
        }

        var bookings = GetBookingQuery()
            .Where(x => x.UserId == userId
                        || x.FlightId == int.Parse(search)).ToList();

        return bookings;
    }
    
    public Booking GetByIdBooking(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    private Booking GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = GetBookingQuery().AsNoTracking().FirstOrDefault(x => x.Id == id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(Booking)} with id:{id} is not found");
        }

        return entity;
    }

    private IQueryable<Booking> GetBookingQuery()
    {
        return _context.Bookings
            .Include(f => f.Flight)
            .ThenInclude(f => f.DepartureAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.Flight)
            .ThenInclude(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(a => a.Flight)
            .ThenInclude(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .Include(a => a.Flight)
            .ThenInclude(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .AsQueryable();
    }
}