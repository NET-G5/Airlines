namespace Airline.Application.Requests.User;

public sealed record GetUserRequest
(
    int Id,
    string UserName,
    string Email,
    string PasswordHash,
    string? PhoneNumber = null,
    bool EmailConfirmed = false,
    bool TwoFactorEnabled = false
);