using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Stores;

public class UserStore : IUserStore
{
    private readonly ICommonRepository _repository;

    public UserStore(ICommonRepository repository)
    {
        _repository = repository?? throw new ArgumentNullException(nameof(repository));
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
        var entity = _repository.Users.GetById(id);

        return entity.ToView();
    }

    public UpdateUserView GetForUpdate(int id)
    {
        var user = _repository.Users.GetById(id);
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
    
    public void AddFlightToUser(int userId, int flightId)
    {
            // Найти пользователя по идентификатору
            var user = _repository.Users.GetAll("") // Подгружаем бронирования пользователя
                .FirstOrDefault(u => u.ID == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var flight = _repository.Flights.GetAll("")
                .FirstOrDefault(f => f.ID == flightId);

            if (flight == null)
            {
                throw new Exception("Flight not found");
            }

            var booking = new Booking
            {
                UserID = userId,
                FlightID = flightId,
                BookingDate = DateTime.Now,
                SeatNumber = "711Ob",
                TotalPrice = flight.Price
            };

            // Добавить бронирование в контекст данных
            _repository.Bookings.Create(booking);

            // Сохранить изменения в базе данных
            _repository.SaveChanges();
        }
    
    public void Delete(int id)
    {
        _repository.Users.Delete(id);
        _repository.SaveChanges();
    }
}