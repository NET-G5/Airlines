namespace Airline.Application.Requests.Flight;

public sealed record GetFlightRequest(
    int Id,
    string FlightNumber,
    int DepartureAirportId,
    int ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    decimal Price);