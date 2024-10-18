using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Country;

namespace Airline.Application.Mappings;

public static class CountryMappings
{
    public static CountryView ToView(this Country country)
    {
        return new CountryView
        {
            ID = country.Id,
            CountryName = country.CountryName
        };
    }
    
    public static UpdateCountryView ToUpdateView(this Country country)
    {
        return new UpdateCountryView
        {
            ID = country.Id,
            CountryName = country.CountryName
        };
    }
    public static Country ToEntity(this CreateCountryView countryView)
    {
        return new Country
        {
            CountryName = countryView.CountryName
        };
    }
    
    public static Country ToEntity(this UpdateCountryView countryView)
    {
        var entity = ToEntity(countryView as CreateCountryView);
        entity.Id = countryView.ID;

        return entity;
    }
}