using Airline.Application.Requests.User;

namespace Airline.Application.Requests.Booking;

public sealed record GetBookingRequest(
    int Id,
    int UserId,
    int FlightId,
    DateTime BookingDate,
    string SeatNumber,
    decimal TotalPrice)
    : UserRequest(UserId);