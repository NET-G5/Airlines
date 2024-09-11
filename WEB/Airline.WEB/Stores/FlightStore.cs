using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure;
using AirlineWeb.Mappings;
using AirlineWeb.Stores.Interfaces;
using AirlineWeb.ViewModels.Flight;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Stores;

public class FlightStore : IFlightStore
{
    private readonly AirlineDbContext _context;
    private readonly ICommonRepository _repository;
    IQueryable<Flight> query;
    
    public FlightStore(ICommonRepository repository, AirlineDbContext context)
    {
        _context = new();
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public List<FlightView> GetAll(string where = "", string to = "",
        string departure = "", string numberOfAdults=null)
    {
        var flights = _repository.Flights.GetAll(where, to, departure, numberOfAdults);
        
        var viewModels = ConvertFlight(flights)
            .Select(x => x.ToView()).ToList();

        return viewModels;
    }

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
    
    public List<Flight> ConvertFlight(List<Flight> flights)
    {
        var flightIds = flights.Select(f => f.ID).ToList();

        var allFlights = _context.Flights
            .Where(f => flightIds.Contains(f.ID))
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.Country)
            .Include(f => f.DepartureAirport)
            .ThenInclude(a => a.City)
            .Include(f => f.ArrivalAirport)
            .ThenInclude(a => a.City)
            .ToList();

        return allFlights;
    }
}