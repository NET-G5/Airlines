using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Airport;

namespace Airline.Application.Mappings;

public static class AirportMappings
{
    public static AirportView ToView(this Airport airport)
    {
        return new AirportView
        {
            Id = airport.Id,
            AirportName = airport.Name,
            CityId = airport.CityId,
            CountryId = airport.CountryId
        };
    }
    
    public static UpdateAirportView ToUpdateView(this Airport airport)
    {
        return new UpdateAirportView
        {
            Id = airport.Id,
            Name = airport.Name,
            CityId = airport.CityId,
            CountryId = airport.CountryId
        };
    }
    public static Airport ToEntity(this CreateAirportView airportView)
    {
        return new Airport
        {
            Name = airportView.Name,
            CityId = airportView.CityId,
            CountryId = airportView.CountryId
        };
    }
    
    public static Airport ToEntity(this UpdateAirportView airportView)
    {
        var entity = ToEntity(airportView as CreateAirportView);
        entity.Id = airportView.Id;

        return entity;
    }
}