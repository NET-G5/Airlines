namespace AirlineWeb.ViewModels.Flight;

public class CreateFlightView
{
    public string FlightNumber { get; set; }
    public int DepartureAirportID { get; set; }
    public int ArrivalAirportID { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
}