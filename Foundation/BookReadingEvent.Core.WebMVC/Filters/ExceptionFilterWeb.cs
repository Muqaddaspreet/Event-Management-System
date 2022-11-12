using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.WebMVC.Filters
{
    public class ExceptionFilterWeb : ExceptionFilterAttribute, IExceptionFilter
    {
        public string View { get; set; }

        public ExceptionFilterWeb(string View)
        {
            this.View = View;

        }

        /// <summary>
        /// Handle Exception
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //gets the abnormal controller and action names, for the record
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];

                //the definition of HandleErrorInfo, for the Error view shows abnormal information
                ExceptionViewModel model = new ExceptionViewModel(filterContext.Exception, controllerName, actionName);

                var result = new ViewResult
                {
                    ViewName = this.View
                };
                var modelMetaData = new EmptyModelMetadataProvider();
                result.ViewData = new ViewDataDictionary(modelMetaData, filterContext.ModelState);
                result.ViewData.Add("HandleException", model);

                filterContext.Result = result;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}

