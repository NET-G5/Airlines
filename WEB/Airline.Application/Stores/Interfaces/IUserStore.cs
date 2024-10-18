using Airline.Application.Requests.User;
using Airline.Application.ViewModels.User;

namespace Airline.Application.Stores.Interfaces;

public interface IUserStore
{
    List<UserView> GetAll(string? search);
    UserView GetById(int id);
    UserView Create(CreateUserRequest request);
    void Update(UpdateUserRequest request);
    void Delete(int id);
    void AddFlightToUser(int userId, int flightId);
}