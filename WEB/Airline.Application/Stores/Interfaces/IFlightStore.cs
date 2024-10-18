using Airline.Application.Requests.Flight;
using Airline.Application.ViewModels.Flight;

namespace Airline.Application.Stores.Interfaces;

public interface IFlightStore
{
    List<FlightView> GetAll(string where="", string to="",
        string departure="", string numberOfAdults=null);
    FlightView GetById(int id);
    FlightView Create(CreateFlightRequest request);
    void Update(UpdateFlightRequest request);
    void Delete(int id);
}