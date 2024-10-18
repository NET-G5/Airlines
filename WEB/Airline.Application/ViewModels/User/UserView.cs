namespace Airline.Application.ViewModels.User;

public class UserView
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<Airline.Domain.Entities.Booking> Bookings { get; set; }
}