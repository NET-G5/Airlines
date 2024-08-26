using Airline.Domain.Common;

namespace Airline.Domain.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    TEntity Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}