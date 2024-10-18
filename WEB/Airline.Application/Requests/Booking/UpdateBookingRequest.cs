using Airline.Application.Requests.User;

namespace Airline.Application.Requests.Booking;

public sealed record UpdateBookingRequest(
    int Id,
    int UserId,
    int FlightId,
    DateTime BookingDate,
    string SeatNumber,
    decimal TotalPrice)
    : CreateBookingRequest(
    Id,
    UserId, 
    FlightId, 
    BookingDate, 
    SeatNumber, 
    TotalPrice);