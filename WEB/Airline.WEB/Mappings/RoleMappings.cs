using Airline.Domain.Entities;
using AirlineWeb.ViewModels.Role;

namespace AirlineWeb.Mappings;

public static class RoleMappings
{
    public static RoleView ToView(this Role role)
    {
        return new RoleView
        {
            ID = role.ID,
            RoleName = role.RoleName
        };
    }
    
    public static UpdateRoleView ToUpdateView(this Role role)
    {
        return new UpdateRoleView
        {
            ID = role.ID,
            RoleName = role.RoleName
        };
    }
    public static Role ToEntity(this CreateRoleView roleView)
    {
        return new Role
        {
            RoleName = roleView.RoleName
        };
    }
    
    public static Role ToEntity(this UpdateRoleView airportView)
    {
        var entity = ToEntity(airportView as CreateRoleView);
        entity.ID = airportView.ID;

        return entity;
    }
}