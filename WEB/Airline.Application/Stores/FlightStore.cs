using Airline.Application.Mappings;
using Airline.Application.Requests.Flight;
using Airline.Application.Stores.Interfaces;
using Airline.Application.ViewModels.Flight;
using Airline.Domain.Interfaces;

namespace Airline.Application.Stores;

public class FlightStore : IFlightStore
{
    private readonly ICommonRepository _repository;
    
    public FlightStore(ICommonRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public List<FlightView> GetAll(string where = "", string to = "",
        string departure = "", string numberOfAdults=null)
    {
        var flights = _repository.Flights.GetAll(where, to, departure, numberOfAdults);
        
        var viewModels = flights
            .Select(x => x.ToView()).ToList();

        return viewModels;
    }

    public FlightView GetById(int id)
    {
        var flight = _repository.Flights.GetByIdFlight(id);
        var viewModel = flight.ToView();

        return viewModel;    
    }
    
    public FlightView Create(CreateFlightRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();

        var flightCreate = _repository.Flights.Create(entity);
        _repository.SaveChanges();
        
        flightCreate.DepartureAirport = _repository.Airports.GetById(flightCreate.ArrivalAirportId);
        flightCreate.ArrivalAirport = _repository.Airports.GetById(flightCreate.DepartureAirportId);
        
        var viewModel = flightCreate.ToView();

        return viewModel;    
    }

    public void Update(UpdateFlightRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();

        _repository.Flights.Update(entity);
        _repository.SaveChanges();    
    }

    public void Delete(int id)
    {
        _repository.Flights.Delete(id);
        _repository.SaveChanges();
    }
}