using Airline.Application.Mappings;
using Airline.Application.Requests.Booking;
using Airline.Application.Stores.Interfaces;
using Airline.Application.ViewModels.Booking;
using Airline.Domain.Interfaces;

namespace Airline.Application.Stores;

public class BookingStore : IBookingStore
{
    private readonly ICommonRepository _repository;

    public BookingStore(ICommonRepository repository)
    {
        _repository = repository?? throw new ArgumentNullException(nameof(repository));
    }
    
    public List<BookingView> GetAll(int userId, string? search)
    {
        var bookings = _repository.Bookings.GetAll(userId, search);
        var viewModels = bookings
            .Select(x => x.ToView()).ToList();

        return viewModels;    }

    public BookingView GetById(int id)
    {
        var booking = _repository.Bookings.GetByIdBooking(id);
        var viewModel = booking.ToView();

        return viewModel;
    }

    public BookingView Create(CreateBookingRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();

        var createdBoooking = _repository.Bookings.Create(entity);
        _repository.SaveChanges();
        
        createdBoooking.User = _repository.Users.GetByIdUser(createdBoooking.UserId);
        createdBoooking.Flight = _repository.Flights.GetByIdFlight(createdBoooking.FlightId);
        
        var viewModel = createdBoooking.ToView();

        return viewModel;    
    }

    public void Update(UpdateBookingRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();

        _repository.Bookings.Update(entity);
        _repository.SaveChanges();
    }

    public void Delete(int id)
    {
        _repository.Bookings.Delete(id);
        _repository.SaveChanges();
    }
}