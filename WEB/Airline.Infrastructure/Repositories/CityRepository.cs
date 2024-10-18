using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Persistence;

namespace Airline.Infrastructure.Repositories;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(AirlineDbContext context) 
        : base(context)
    {
    }
}