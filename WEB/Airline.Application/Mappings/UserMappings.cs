using Airline.Application.Requests.User;
using Airline.Application.ViewModels.User;
using Airline.Domain.Entities;

namespace Airline.Application.Mappings;

public static class UserMappings
{
    public static UserView ToView(this User user)
    {
        return new UserView
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    }
    
    public static User ToView(this UserView userView)
    {
        return new User
        {
            Id = userView.Id,
            UserName = userView.UserName,
            Email = userView.Email
        };
    }
    
    public static User ToEntity(this CreateUserRequest request)
    {
        return new User
        {
            UserName = request.UserName,
            PasswordHash = request.PasswordHash,
            Email = request.Email
        };
    }
    
    public static User ToEntity(this UpdateUserRequest request)
    {
        var entity = ToEntity(request as CreateUserRequest);
        entity.Id = request.Id;

        return entity;
    }
}