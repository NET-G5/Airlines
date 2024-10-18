using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AirlineDbContext _context;
    
    public UserRepository(AirlineDbContext context)
    {
        _context = context;
    }
    
    public List<User> GetAll(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetUserQuery().ToList();
        }
            
        var users = GetUserQuery()
            .Where(x => x.UserName == search || x.Email == search).ToList();

        return users;
    }
    
    public List<User> GetAll()
        => _context.Users.AsNoTracking().ToList();

    public User GetById(int id) => 
        GetOrThrow(id);
    
    public User GetByIdUser(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    public User Create(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<User>().Add(entity);

        return entity;
    }

    public void Update(User entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<User>().Update(entity);
    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Set<User>().Remove(entity);
    }

    public bool Exists(int id)
        => _context.Users.Any(x => x.Id == id);

    private User GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = GetUserQuery().AsNoTracking().FirstOrDefault(x => x.Id == id);

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