namespace AirlineWeb.ViewModels.User;

public class UserView
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime BookingDate { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string SeatNumber { get; set; }
    public decimal TotalPrice { get; set; }
}