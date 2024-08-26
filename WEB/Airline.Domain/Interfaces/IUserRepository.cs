using Airline.Domain.Entities;

namespace Airline.Domain.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    List<User> GetAll(string? search);
}