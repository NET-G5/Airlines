using AirlineWeb.ViewModels.Flight;

namespace AirlineWeb.Stores.Interfaces;

public interface IFlightStore
{
    List<FlightView> GetAll(string where="", string to="",
        string departure="", string numberOfAdults=null);
    FlightView GetById(int id);
    UpdateFlightView GetForUpdate(int id);
    FlightView Create(UpdateFlightView flightView);
    void Update(UpdateFlightView flightView);
    void Delete(int id);
}