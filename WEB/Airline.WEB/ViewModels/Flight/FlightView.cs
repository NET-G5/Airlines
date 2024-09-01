namespace AirlineWeb.ViewModels.Flight;

public class FlightView
{
    public int ID { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirportCountry { get; set; }
    public string DepartureAirportCity { get; set; }
    public string ArrivalAirportCountry { get; set; }
    public string ArrivalAirportCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
}