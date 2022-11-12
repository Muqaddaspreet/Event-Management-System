using BookReadingEvent.Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace BookReadingEvent.Core.WebMVC.Filters
{
    public class ActionFilter : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// Action Executed
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Guid corelationId = (Guid)context.HttpContext.Items["CorelationId"];

            //post processing logic here

            //post processing logic
            base.OnActionExecuted(context);
        }

        /// <summary>
        /// Action Executing
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["CorelationId"] = Guid.NewGuid();

            //post processing logic here

            //pre processing logic
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Result Executing
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (objectResult != null
                && objectResult.Value != null
                && typeof(OperationResult<>).Name == actionDescriptor.MethodInfo.ReturnType.Name
                )
            {
                Type operationResultType = typeof(OperationResult<>);
                Type genericType = operationResultType.MakeGenericType(actionDescriptor.MethodInfo.ReturnType.GenericTypeArguments);
                dynamic actionResult = Convert.ChangeType(objectResult.Value, genericType);
                if (!actionResult.IsSuccess)
                {
                    int errorCode = ErrorCodeToHttpCodeMapping(actionResult.MainMessage.Code);
                    objectResult.StatusCode = errorCode;
                }

            }
            base.OnResultExecuting(context);
        }

        /// <summary>
        /// Error code to Http code mapping
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private int ErrorCodeToHttpCodeMapping(string errorCode)
        {
            ResourceManager rm = new ResourceManager("BookReadingEvent.Core.WebMVC.ErrorResource",
                typeof(BookReadingEvent.Core.WebMVC.ErrorResource).GetTypeInfo().Assembly);

            String httpCode = rm.GetString(errorCode);
            return Int32.Parse(httpCode);
        }
    }
}
