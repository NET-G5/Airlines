using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
{
    public BookingRepository(AirlineDbContext context) : base(context) { }
    
    public List<Booking> GetAll(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetAll();
        }

        var bookings = _context.Bookings
            .Where(x => x.UserID == int.Parse(search)
            || x.FlightID == int.Parse(search)).ToList();

        return bookings;
    }
}