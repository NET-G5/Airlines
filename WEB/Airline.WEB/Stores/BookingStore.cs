using Airline.Domain.Interfaces;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.Booking;

namespace AirlineWeb.Stores;

public class BookingStore : IBookingStore
{
    private readonly ICommonRepository _repository;

    public BookingStore(ICommonRepository repository)
    {
        _repository = repository;
    }
    
    public List<BookingView> GetAll(string? search)
    {
        var bookings = _repository.Bookings.GetAll(search);
        var viewModels = bookings
            .Select(x => x.ToView()).ToList();

        return viewModels;    }

    public BookingView GetById(int id)
    {
        var booking = _repository.Bookings.GetById(id);
        var viewModel = booking.ToView();

        return viewModel;
    }

    public UpdateBookingView GetForUpdate(int id)
    {
        var booking = _repository.Bookings.GetById(id);
        var viewModel = booking.ToUpdateView();

        return viewModel;
    }

    public BookingView Create(CreateBookingView bookingView)
    {
        ArgumentNullException.ThrowIfNull(bookingView);

        var entity = bookingView.ToEntity();

        var createdBoooking = _repository.Bookings.Create(entity);
        _repository.SaveChanges();
        
        createdBoooking.User = _repository.Users.GetById(createdBoooking.UserID);
        createdBoooking.Flight = _repository.Flights.GetById(createdBoooking.FlightID);
        
        var viewModel = createdBoooking.ToView();

        return viewModel;    
    }

    public void Update(UpdateBookingView bookingView)
    {
        ArgumentNullException.ThrowIfNull(bookingView);

        var entity = bookingView.ToEntity();

        _repository.Bookings.Update(entity);
        _repository.SaveChanges();
    }

    public void Delete(int id)
    {
        _repository.Bookings.Delete(id);
        _repository.SaveChanges();
    }
}