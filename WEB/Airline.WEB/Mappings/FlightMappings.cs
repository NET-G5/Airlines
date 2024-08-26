using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Flight;

namespace AirlineWeb.Extensions;

public static class FlightMappings
{
    public static FlightView ToView(this Flight flight)
    {
        return new FlightView
        {
            ID = flight.ID,
            FlightNumber = flight.FlightNumber,
            DepartureAirportID = flight.DepartureAirportID,
            ArrivalAirportID = flight.ArrivalAirportID,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price
        };
    }
    
    public static UpdateFlightView ToUpdateView(this Flight flight)
    {
        return new UpdateFlightView
        {
            ID = flight.ID,
            FlightNumber = flight.FlightNumber,
            DepartureAirportID = flight.DepartureAirportID,
            ArrivalAirportID = flight.ArrivalAirportID,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price
        };
    }
    public static Flight ToEntity(this CreateFlightView flightView)
    {
        return new Flight
        {
            FlightNumber = flightView.FlightNumber,
            DepartureAirportID = flightView.DepartureAirportID,
            ArrivalAirportID = flightView.ArrivalAirportID,
            DepartureTime = flightView.DepartureTime,
            ArrivalTime = flightView.ArrivalTime,
            Price = flightView.Price
        };
    }
    
    public static Flight ToEntity(this UpdateFlightView flightView)
    {
        var entity = ToEntity(flightView as CreateFlightView);
        entity.ID = flightView.ID;

        return entity;
    }
}