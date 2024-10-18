using Airline.Application.Requests.Booking;
using Airline.Application.ViewModels.Booking;

namespace Airline.Application.Stores.Interfaces;

public interface IBookingStore
{
    List<BookingView> GetAll(int userId, string? search);
    BookingView GetById(int id);
    BookingView Create(CreateBookingRequest request);
    void Update(UpdateBookingRequest request);
    void Delete(int id);
}