using Airline.Domain.Interfaces;
using AirlineWeb.Extensions;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.Flight;

namespace AirlineWeb.Stores;

public class FlightStore : IFlightStore
{
    private readonly ICommonRepository _repository;
    
    public List<FlightView> GetAll(string? search)
    {
        var flights = _repository.Flights.GetAll(search);
        var viewModels = flights
            .Select(x => x.ToView()).ToList();

        return viewModels;    }

    public FlightView GetById(int id)
    {
        var flight = _repository.Flights.GetById(id);
        var viewModel = flight.ToView();

        return viewModel;    }

    public UpdateFlightView GetForUpdate(int id)
    {
        var flight = _repository.Flights.GetById(id);
        var viewModel = flight.ToUpdateView();

        return viewModel;
    }

    public FlightView Create(UpdateFlightView flightView)
    {
        ArgumentNullException.ThrowIfNull(flightView);

        var entity = flightView.ToEntity();

        var flightCreate = _repository.Flights.Create(entity);
        _repository.SaveChanges();
        
        flightCreate.DepartureAirport = _repository.Airports.GetById(flightCreate.ArrivalAirportID);
        flightCreate.ArrivalAirport = _repository.Airports.GetById(flightCreate.DepartureAirportID);
        var viewModel = flightCreate.ToView();

        return viewModel;    }

    public void Update(UpdateFlightView flightView)
    {
        ArgumentNullException.ThrowIfNull(flightView);

        var entity = flightView.ToEntity();

        _repository.Flights.Update(entity);
        _repository.SaveChanges();    }

    public void Delete(int id)
    {
        _repository.Flights.Delete(id);
        _repository.SaveChanges();
    }
}