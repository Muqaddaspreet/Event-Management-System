using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace BookReadingEvent.Web.Infrastructure
{
    public class CustomAuthFilter : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            List<String> listofroles = new List<string>(Roles.Split(","));

            string user = Convert.ToString(context.HttpContext.Session.GetString("EmailId"));
            string role = Convert.ToString(context.HttpContext.Session.GetString("Role"));
            if (!string.IsNullOrEmpty(user))
            {

                if (!listofroles.Contains(role))
                {
                    context.HttpContext.Session.Clear();
                    context.Result = new RedirectToRouteResult
                    (
                    new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "Login"
                    }));
                }
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Login"
                }));
            }
        }
    }
}