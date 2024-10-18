namespace Airline.Application.Requests.Flight;

public record CreateFlightRequest(
    int Id,
    string FlightNumber,
    int DepartureAirportId,
    int ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    decimal Price);