using System.Security.Claims;
using Airline.Application.Requests.User;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AirlineWeb.Filters;

public class UserRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var arg in context.ActionArguments)
        {
            if (arg.Value is UserRequest userRequest)
            {
                var user = context.HttpContext.User;
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (int.TryParse(userId, out var result))
                {
                    var modifiedRequest = userRequest with
                    {
                        Id = result
                    };

                    context.ActionArguments[arg.Key] = modifiedRequest;
                }
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // No logic needed for after execution
    }
}
