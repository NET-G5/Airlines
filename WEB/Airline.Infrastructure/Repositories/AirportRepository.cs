using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
{
    public AirportRepository(AirlineDbContext context) : base(context) { }
}