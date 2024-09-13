using Airline.Domain.Entities;
using AirlineWeb.ViewModels.City;

namespace AirlineWeb.Extensions;

public static class CityMappings
{
    public static CityView ToView(this City city)
    {
        return new CityView
        {
            ID = city.ID,
            CityName = city.CityName,
            CountryID = city.CountryID
        };
    }
    
    public static UpdateCityView ToUpdateView(this City city)
    {
        return new UpdateCityView
        {
            ID = city.ID,
            CityName = city.CityName,
            CountryID = city.CountryID
        };
    }
    public static City ToEntity(this CreateCityView cityView)
    {
        return new City
        {
            CityName = cityView.CityName,
            CountryID = cityView.CountryID
        };
    }
    
    public static City ToEntity(this UpdateCityView cityView)
    {
        var entity = ToEntity(cityView as CreateCityView);
        entity.ID = cityView.ID;

        return entity;
    }
}