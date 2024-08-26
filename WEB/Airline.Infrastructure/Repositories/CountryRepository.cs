using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(AirlineDbContext context) : base(context) { }
}