using Airline.Domain.Entities;
using AirlineWeb.ViewModels.UserRole;

namespace AirlineWeb.Extensions;

public static class UserRoleMappings
{
    public static UserRoleView ToView(this UserRole userRole)
    {
        return new UserRoleView
        {
            ID = userRole.ID,
            UserID = userRole.UserID,
            RoleID = userRole.RoleID
        };
    }
    
    public static UpdateUserRoleView ToUpdateView(this UserRole userRole)
    {
        return new UpdateUserRoleView
        {
            ID = userRole.ID,
            UserID = userRole.UserID,
            RoleID = userRole.RoleID
        };
    }
    public static UserRole ToEntity(this CreateUserRoleView userRoleView)
    {
        return new UserRole
        {
            UserID = userRoleView.UserID,
            RoleID = userRoleView.RoleID
        };
    }
    
    public static UserRole ToEntity(this UpdateUserRoleView userRoleView)
    {
        var entity = ToEntity(userRoleView as CreateUserRoleView);
        entity.ID = userRoleView.ID;

        return entity;
    }
}