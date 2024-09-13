using Airline.Domain.Entities;

namespace Airline.Domain.Interfaces;

public interface IFlightRepository : IRepositoryBase<Flight>
{
    List<Flight> GetAll(string where="", string to="",
        string departure="", string numberOfAdults="");
    Flight GetByIdFlight(int id);
}