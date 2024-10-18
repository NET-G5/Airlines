using Airline.Domain.Entities;
using AirlineWeb.ViewModels.City;

namespace Airline.Application.Mappings;

public static class CityMappings
{
    public static CityView ToView(this City city)
    {
        return new CityView
        {
            Id = city.Id,
            CityName = city.CityName,
            CountryId = city.CountryId
        };
    }
    
    public static UpdateCityView ToUpdateView(this City city)
    {
        return new UpdateCityView
        {
            Id = city.Id,
            CityName = city.CityName,
            CountryId = city.CountryId
        };
    }
    public static City ToEntity(this CreateCityView cityView)
    {
        return new City
        {
            CityName = cityView.CityName,
            CountryId = cityView.CountryId
        };
    }
    
    public static City ToEntity(this UpdateCityView cityView)
    {
        var entity = ToEntity(cityView as CreateCityView);
        entity.Id = cityView.Id;

        return entity;
    }
}