using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AirlineDbContext _context;

    public RoleRepository(AirlineDbContext context)
    {
        _context = context;
    }
    public List<Role> GetAll() =>
    _context.Set<Role>().AsNoTracking().ToList();

    public Role GetById(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    public Role Create(Role entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<Role>().Add(entity);

        return entity;
    }

    public void Update(Role entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<Role>().Update(entity);
    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Set<Role>().Remove(entity);
    }
    
    private Role GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = _context.Set<Role>()
            .AsNoTracking()
            .FirstOrDefault(x => x.ID == id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(Role)} with id:{id} is not found");
        }

        return entity;
    }
}