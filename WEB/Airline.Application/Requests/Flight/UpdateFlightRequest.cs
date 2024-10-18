namespace Airline.Application.Requests.Flight;

public record UpdateFlightRequest(
    int Id,
    string FlightNumber,
    int DepartureAirportId,
    int ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    decimal Price)
    : CreateFlightRequest(
        Id, 
        FlightNumber, 
        DepartureAirportId, 
        ArrivalAirportId, 
        DepartureTime, 
        ArrivalTime, 
        Price);