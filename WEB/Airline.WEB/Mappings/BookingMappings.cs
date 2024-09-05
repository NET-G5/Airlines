using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Booking;

namespace AirlineWeb.Extensions;

public static class BookingMappings
{
    public static BookingView ToView(this Booking booking)
    {
        return new BookingView
        {
            ID = booking.ID,
            UserID = booking.UserID,
            BookingDate = booking.BookingDate,
            SeatNumber = booking.SeatNumber,
            TotalPrice = booking.TotalPrice
        };
    }
    
    public static UpdateBookingView ToUpdateView(this Booking booking)
    {
        return new UpdateBookingView
        {
            ID = booking.ID,
            UserID = booking.UserID,
            FlightID = booking.FlightID,
            BookingDate = booking.BookingDate,
            SeatNumber = booking.SeatNumber,
            TotalPrice = booking.TotalPrice
        };
    }
    public static UpdateBookingView ToUpdateView(this BookingView booking)
    {
        return new UpdateBookingView
        {
            ID = booking.ID,
            UserID = booking.UserID,
            FlightID = booking.FlightID,
            BookingDate = booking.BookingDate,
            SeatNumber = booking.SeatNumber,
            TotalPrice = booking.TotalPrice
        };
    }
    public static Booking ToEntity(this CreateBookingView bookingView)
    {
        return new Booking
        {
            UserID = bookingView.UserID,
            FlightID = bookingView.FlightID,
            BookingDate = bookingView.BookingDate,
            SeatNumber = bookingView.SeatNumber,
            TotalPrice = bookingView.TotalPrice
        };
    }
    
    public static Booking ToEntity(this UpdateBookingView bookingView)
    {
        var entity = ToEntity(bookingView as CreateBookingView);
        entity.ID = bookingView.ID;

        return entity;
    }
}