using Airline.Domain.Entities;
using AirlineWeb.ViewModels.User;

namespace AirlineWeb.Extensions;

public static class UserMappings
{
    public static UserView ToView(this User user)
    {
        return new UserView
        {
            ID = user.ID,
            Username = user.UserName,
            Email = user.Email,
        };
    }
    
    public static User ToView(this UserView userView)
    {
        return new User
        {
            ID = userView.ID,
            UserName = userView.Username,
            Email = userView.Email
        };
    }
    
    public static UpdateUserView ToUpdateView(this User user)
    {
        return new UpdateUserView
        {
            ID = user.ID,
            Username = user.UserName,
            PasswordHash = user.PasswordHash,
            Email = user.Email
        };
    }
    public static User ToEntity(this CreateUserView userView)
    {
        return new User
        {
            UserName = userView.Username,
            PasswordHash = userView.PasswordHash,
            Email = userView.Email
        };
    }
    
    public static User ToEntity(this UpdateUserView userView)
    {
        var entity = ToEntity(userView as CreateUserView);
        entity.ID = userView.ID;

        return entity;
    }
}