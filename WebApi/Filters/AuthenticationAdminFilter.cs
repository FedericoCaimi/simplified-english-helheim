using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BusinessLogic.Interface;
using Exceptions;

namespace WebApi.Filters
{
    public class AuthenticationAdminFilter : Attribute, IAuthorizationFilter
    {
        IAuthenticationLogic AuthenticationLogic;
        public AuthenticationAdminFilter(IAuthenticationLogic authenticationLogic)
        {
            this.AuthenticationLogic = authenticationLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (token == null)
            {
                JsonResult json = new JsonResult(new { message = "No access token found on the request" });
                json.StatusCode = 401;
                context.Result = json;
            }
            else
            {
                try
                {
                    Guid guidToken = Guid.Parse(token);
                    if (!this.AuthenticationLogic.IsLoggedInAndAuthorized(guidToken, "Admin"))
                    {
                        JsonResult json = new JsonResult(new { message = "User not authorized to use the service, try to login first" });
                        json.StatusCode = 401;
                        context.Result = json;
                    }
                }
                catch (BadLoginException)
                {
                    JsonResult json = new JsonResult(new { message = "User not authorized to use the service, try to login first" });
                    json.StatusCode = 401;
                    context.Result = json;
                }
                catch (DBKeyNotFoundException)
                {
                    JsonResult json = new JsonResult(new { message = "User not authorized to use the service, try to login first" });
                    json.StatusCode = 401;
                    context.Result = json;
                }
                catch (Exception)
                {
                    JsonResult json = new JsonResult(new { message = "Something went wrong on the server" });
                    json.StatusCode = 500;
                    context.Result = json;
                }
            }
        }
    }
}
