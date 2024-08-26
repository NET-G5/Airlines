using Airline.Domain.Entities;

namespace Airline.Domain.Interfaces;

public interface IFlightRepository : IRepositoryBase<Flight>
{
    List<Flight> GetAll(string? search);
}