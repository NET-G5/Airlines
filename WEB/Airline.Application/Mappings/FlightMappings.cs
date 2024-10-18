using Airline.Application.Requests.Flight;
using Airline.Application.ViewModels.Flight;
using Airline.Domain.Entities;

namespace Airline.Application.Mappings;

public static class FlightMappings
{
    public static FlightView ToView(this Flight flight)
    {
        return new FlightView
        {
            Id = flight.Id,
            FlightNumber = flight.FlightNumber,
            DepartureAirportCountry =  $"Country: {flight.DepartureAirport.Country.CountryName}",
            DepartureAirportCity =  $"City: {flight.DepartureAirport.City.CityName}",
            ArrivalAirportCountry = $"Country: {flight.ArrivalAirport.Country.CountryName}",
            ArrivalAirportCity = $"City: {flight.ArrivalAirport.City.CityName}",
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price
        };
    }
    
    public static Flight ToEntity(this CreateFlightRequest request)
    {
        return new Flight
        {
            FlightNumber = request.FlightNumber,
            DepartureAirportId = request.DepartureAirportId,
            ArrivalAirportId = request.ArrivalAirportId,
            DepartureTime = request.DepartureTime,
            ArrivalTime = request.ArrivalTime,
            Price = request.Price
        };
    }
    
    public static Flight ToEntity(this UpdateFlightRequest request)
    {
        var entity = ToEntity(request as CreateFlightRequest);
        entity.Id = request.Id;

        return entity;
    }
}