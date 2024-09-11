namespace AirlineWeb.ViewModels.User;

public class UserView
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<Airline.Domain.Entities.Booking> Bookings { get; set; }
}