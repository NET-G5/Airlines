using Airline.Application.Requests.User;

namespace Airline.Application.Requests.Booking;

public sealed record BookingRequest(
    int Id,
    int UserId)
    : UserRequest(UserId);