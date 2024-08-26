using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Airport;

namespace AirlineWeb.Extensions;

public static class AirportMappings
{
    public static AirportView ToView(this Airport airport)
    {
        return new AirportView
        {
            ID = airport.ID,
            AirportName = airport.Name,
            CityID = airport.CityID,
            CountryID = airport.CountryID
        };
    }
    
    public static UpdateAirportView ToUpdateView(this Airport airport)
    {
        return new UpdateAirportView
        {
            ID = airport.ID,
            Name = airport.Name,
            CityID = airport.CityID,
            CountryID = airport.CountryID
        };
    }
    public static Airport ToEntity(this CreateAirportView airportView)
    {
        return new Airport
        {
            Name = airportView.Name,
            CityID = airportView.CityID,
            CountryID = airportView.CountryID
        };
    }
    
    public static Airport ToEntity(this UpdateAirportView airportView)
    {
        var entity = ToEntity(airportView as CreateAirportView);
        entity.ID = airportView.ID;

        return entity;
    }
}