using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AirlineDbContext context) : base(context) {}
    
    public List<User> GetAll(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetUserQuery().ToList();
        }
            
        var users = GetUserQuery()
            .Where(x => x.Username == search || x.Email == search).ToList();

        return users;
    }
    
    public User GetByIdUser(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    private User GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = GetUserQuery().AsNoTracking().FirstOrDefault(x => x.ID == id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(User)} with id:{id} is not found");
        }

        return entity;
    }

    private IQueryable<User> GetUserQuery()
    {
        return _context.Users
            .Include(u => u.Bookings)
            .ThenInclude(b => b.Flight)
            .ThenInclude(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(u => u.Bookings)
            .ThenInclude(b => b.Flight)
            .ThenInclude(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .Include(u => u.Bookings)
            .ThenInclude(b => b.Flight)
            .ThenInclude(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(u => u.Bookings)
            .ThenInclude(b => b.Flight)
            .ThenInclude(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .AsQueryable();
    }
}