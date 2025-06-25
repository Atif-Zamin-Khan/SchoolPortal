using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CollegeAPIs.Shared.Filters
{
    public class SuperAuthorizationFilter : Attribute
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

                // Check if the user has the "superAdmin" role
                if (!context.HttpContext.User.IsInRole("superAdmin"))
                {
                    // If not an Admin, deny access with Forbidden status
                    context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                }

          }
       

    }
}
