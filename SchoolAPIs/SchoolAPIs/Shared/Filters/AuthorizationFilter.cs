using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;

public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
{


    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Check if the user is authenticated
        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
        {
            // If not authenticated, return unauthorized
            context.Result = new UnauthorizedResult();
            return;
        }

        // Retrieve the role claim from the user's claims
        var employeeRoleClaim = context.HttpContext.User.FindFirst(ClaimTypes.Role);

        if (employeeRoleClaim == null)
        {
            // If no role claim is found, deny access
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        // Retrieve the role name from the claim
        string role = employeeRoleClaim.Value;


        // Check if the user has the "SuperAdmin" role
        if (role.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase))
        {
            // User is a SuperAdmin
            // Proceed with the request (no action needed here)
            return;
        }

        // Check if the user has the "Administrator" role
        else if (role.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
        {
            // User is an Administrator
            // Proceed with the request (no action needed here)
            return;
        }

        // Check if the user has the "HOD" role
        else if (role.Equals("HOD", StringComparison.OrdinalIgnoreCase))
        {
            // User is a Head of Department (HOD)
            // Proceed with the request (no action needed here)
            return;
        }

        else
        {
            // If the role is unknown, deny access
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

    }
}













