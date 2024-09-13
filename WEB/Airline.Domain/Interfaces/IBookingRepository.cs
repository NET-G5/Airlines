using Airline.Domain.Entities;

namespace Airline.Domain.Interfaces;

public interface IBookingRepository : IRepositoryBase<Booking>
{
    List<Booking> GetAll(string? search);
    Booking GetByIdBooking(int id);
}