namespace Airline.Application.Requests.User;

public sealed record UpdateUserRequest(
    int Id,
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