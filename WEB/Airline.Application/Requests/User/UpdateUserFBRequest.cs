using Airline.Application.Requests.Flight;

namespace Airline.Application.Requests.User;

public sealed record UpdateUserFBRequest(
    int Id,
    string FlightNumber,
    string DepartureAirport,
    string ArrivalAirport,
    string BookingDate,
    string SeatNumber,
    string TotalPrice,
    string UserName,
    string Email,
    string PasswordHash,
    string? PhoneNumber = null,
    bool EmailConfirmed = false,
    bool TwoFactorEnabled = false) 
        : CreateUserRequest(
            Id,
            UserName,
            Email,
            PasswordHash,
            PhoneNumber,
            EmailConfirmed,
            TwoFactorEnabled);