using Airline.Application.Requests.User;

namespace Airline.Application.Requests.Booking;

public record CreateBookingRequest(
    int Id,
    int UserId,
    int FlightId,
    DateTime BookingDate,
    string SeatNumber,
    decimal TotalPrice)
    : UserRequest(UserId);