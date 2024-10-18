namespace Airline.Application.Requests.Auth;

public sealed record LoginUserRequest(string Email,bool RememberMe, string Password);
