using Airline.Domain.Common;
using Airline.Domain.Exceptions;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected readonly AirlineDbContext _context;
    
    protected RepositoryBase(AirlineDbContext context)
    {
        _context = context; 
    }
    
    public List<TEntity> GetAll() =>
        _context.Set<TEntity>().AsNoTracking().ToList();

    public TEntity GetById(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    public TEntity Create(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Add(entity);

        return entity;
    }

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Set<TEntity>().Remove(entity);
    }
    
    public bool Exists(int id)
        => _context.Set<TEntity>().Any(x => x.Id == id);
    
    private TEntity GetOrThrow(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is not initialized.");
        }

        var entity = _context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(x => x.Id.Equals(id));

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(TEntity)} with id:{id} is not found");
        }

        return entity;
    }
}