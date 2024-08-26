using AirlineWeb.ViewModels.Booking;
using AirlineWeb.ViewModels.Flight;

namespace AirlineWeb.Stores.Interfaces;

public interface IFlightStore
{
    List<FlightView> GetAll(string? search);
    FlightView GetById(int id);
    UpdateFlightView GetForUpdate(int id);
    FlightView Create(UpdateFlightView flightView);
    void Update(UpdateFlightView flightView);
    void Delete(int id);
}