using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookReadingEvent.Core.WebMVC.Filters
{
    public class ExceptionFilterWebApi : ExceptionFilterAttribute, IExceptionFilter
    {
        public string View { get; set; }

        public ExceptionFilterWebApi()
        {

        }

        public override void OnException(ExceptionContext filterContext)
        {

            if (!filterContext.ExceptionHandled)
            {
                HttpStatusCode status = HttpStatusCode.InternalServerError;
                String message = String.Empty;
                HttpResponse response = filterContext.HttpContext.Response;
                response.StatusCode = (int)status;
                response.ContentType = "application/json";
                var err = message + " " + filterContext.Exception.StackTrace;
                var error = JsonConvert.SerializeObject(new { error = err });
                filterContext.ExceptionHandled = true;
                response.WriteAsync(error);
            }
        }
    }
}
