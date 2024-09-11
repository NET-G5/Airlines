namespace AirlineWeb.ViewModels.Booking;

public class BookingView
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int FlightID { get; set; }
    public DateTime BookingDate { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirportCountry { get; set; }
    public string DepartureAirportCity { get; set; }
    public string ArrivalAirportCountry { get; set; }
    public string ArrivalAirportCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string SeatNumber { get; set; }
    public decimal TotalPrice { get; set; }
}