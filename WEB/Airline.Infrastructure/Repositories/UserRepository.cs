using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AirlineDbContext context) : base(context) {}
    
    public List<User> GetAll(string? search)
    {
            if (string.IsNullOrEmpty(search))
            {
                return GetAll();
            }

            var users = _context.Users
                .Where(x => x.Username == search
                || x.Email == search)
                .ToList();

            return users;
    }
}