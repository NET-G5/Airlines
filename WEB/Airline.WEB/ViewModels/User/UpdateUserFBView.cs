namespace AirlineWeb.ViewModels.User;

public class UpdateUserFBView : CreateUserView
{
    public int ID { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public string BookingDate { get; set; }
    public string SeatNumber { get; set; }
    public string TotalPrice { get; set; }
}