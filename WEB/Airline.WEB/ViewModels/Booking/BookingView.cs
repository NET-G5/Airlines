namespace AirlineWeb.ViewModels.Booking;

public class BookingView
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int FlightID { get; set; }
    public DateTime BookingDate { get; set; }
    public string SeatNumber { get; set; }
    public decimal TotalPrice { get; set; }
}