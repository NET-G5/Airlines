using Airline.Domain.Entities;
using Airline.Domain.Interfaces;

namespace Airline.Infrastructure.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(AirlineDbContext context) : base(context) { }
}