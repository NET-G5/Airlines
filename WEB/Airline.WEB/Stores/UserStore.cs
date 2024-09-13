using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Stores;

public class UserStore : IUserStore
{
    private readonly ICommonRepository _repository;
    private readonly char[] Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    private readonly Random Random;

    public UserStore(ICommonRepository repository)
    {
        _repository = repository?? throw new ArgumentNullException(nameof(repository));
        Random = new Random();
    }
    
    public List<UserView> GetAll(string? search)
    {
        var entities = _repository.Users.GetAll(search);
        var viewModels = entities
            .Select(x => x.ToView())
            .ToList();

        return viewModels;
    }

    public UserView GetById(int id)
    {
        var entity = _repository.Users.GetByIdUser(id);

        return entity.ToView();
    }

    public UpdateUserView GetForUpdate(int id)
    {
        var user = _repository.Users.GetByIdUser(id);
        var viewModel = user.ToUpdateView();

        return viewModel;
    }

    public UserView Create(CreateUserView userView)
    {
        ArgumentNullException.ThrowIfNull(userView);

        var entity = userView.ToEntity();

        var createdUser = _repository.Users.Create(entity);
        _repository.SaveChanges();
        
        var viewModel = createdUser.ToView();

        return viewModel;
    }

    public void Update(UpdateUserView userView)
    {
        ArgumentNullException.ThrowIfNull(userView);

        var entity = userView.ToEntity();

        _repository.Users.Update(entity);
        _repository.SaveChanges();
    }
    
    public void Delete(int id)
    {
        _repository.Users.Delete(id);
        _repository.SaveChanges();
    }
    
    public void AddFlightToUser(int userId, int flightId)
    {
        var user = _repository.Users.GetByIdUser(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var flight = _repository.Flights.GetByIdFlight(flightId);
        if (flight == null)
        {
            throw new Exception("Flight not found");
        }

        var booking = new Booking
        {
            UserID = userId,
            FlightID = flightId,
            BookingDate = DateTime.Now,
            SeatNumber = GenerateRandomString(5),
            TotalPrice = flight.Price
        };

        _repository.Bookings.Create(booking);

        _repository.SaveChanges();
    }
    
    public string GenerateRandomString(int length)
    {
        var stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = Chars[Random.Next(Chars.Length)];
        }
        return new string(stringChars);
    }
}