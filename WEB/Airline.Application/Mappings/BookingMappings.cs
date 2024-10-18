using Airline.Application.Requests.Booking;
using Airline.Application.ViewModels.Booking;
using Airline.Domain.Entities;

namespace Airline.Application.Mappings;

public static class BookingMappings
{
    public static BookingView ToView(this Booking booking)
    {  
    return new BookingView
        {
            Id = booking.Id,
            UserId = booking.UserId,
            BookingDate = booking.BookingDate,
            SeatNumber = booking.SeatNumber,
            TotalPrice = booking.TotalPrice,
            DepartureAirportCountry = booking.Flight?.DepartureAirport?.Country?.CountryName ?? "Unknown",
            DepartureAirportCity = booking.Flight?.DepartureAirport?.City?.CityName ?? "Unknown",
            ArrivalAirportCountry = booking.Flight?.ArrivalAirport?.Country?.CountryName ?? "Unknown",
            ArrivalAirportCity = booking.Flight?.ArrivalAirport?.City?.CityName ?? "Unknown",
        };
    }
    
    public static Booking ToEntity(this CreateBookingRequest request)
    {
        return new Booking
        {
            UserId = request.UserId,
            FlightId = request.FlightId,
            BookingDate = request.BookingDate,
            SeatNumber = request.SeatNumber,
            TotalPrice = request.TotalPrice
        };
    }
    
    public static Booking ToEntity(this UpdateBookingRequest request)
    {
        var entity = ToEntity(request as CreateBookingRequest);
        entity.Id = request.Id;

        return entity;
    }
}