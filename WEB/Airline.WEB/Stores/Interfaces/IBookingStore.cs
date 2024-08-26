using AirlineWeb.ViewModels.Booking;

namespace AirlineWeb.Stores.Interfaces;

public interface IBookingStore
{
    List<BookingView> GetAll(string? search);
    BookingView GetById(int id);
    UpdateBookingView GetForUpdate(int id);
    BookingView Create(CreateBookingView bookingView);
    void Update(UpdateBookingView bookingView);
    void Delete(int id);
}