namespace Airline.Application.Requests.User;

public record CreateUserRequest
(
    int Id,
    string UserName,
    string Email,
    string PasswordHash,
    string? PhoneNumber = null,
    bool EmailConfirmed = false,
    bool TwoFactorEnabled = false
);