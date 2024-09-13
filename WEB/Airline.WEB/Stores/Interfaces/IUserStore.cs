using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Stores.Interfaces;

public interface IUserStore
{
    List<UserView> GetAll(string? search);
    UserView GetById(int id);
    UpdateUserView GetForUpdate(int id);
    UserView Create(CreateUserView userView);
    void Update(UpdateUserView userView);
    void Delete(int id);
    void AddFlightToUser(int userId, int flightId);
}