using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookReadingEvent.Core.WebMVC
{
    public abstract class BaseController : Controller
    {
        protected IExceptionManager ExceptionManager { get; set; }
        protected BaseController()
        {

        }

        protected BaseController(IExceptionManager exceptionManager)
        {
            this.ExceptionManager = exceptionManager;
        }

        /// <summary>
        /// Handles the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="redirectToActionOnSuccess">The redirect to action.</param>
        /// <returns></returns>
        protected ActionResult HandleResult<T>(OperationResult<T> result, ViewModel viewModel, string redirectToActionOnSuccess, string redirectToActionOnFailure)
        {
            if (result.IsSuccess)
            {
                return RedirectToAction(redirectToActionOnSuccess);
            }
            else
            {
                ModelState.AddModelError(result.MainMessage.Code, result.MainMessage.Text);
                if (result.AssociatedMessages.Count<Message>() > 0)
                {
                    foreach (var item in result.AssociatedMessages)
                    {
                        ModelState.AddModelError(item.Code, item.Text);
                    }
                }
            }

            return View(redirectToActionOnFailure, viewModel);
        }

        /// <summary>
        /// Handles the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="redirectToActionOnSuccess">The redirect to action on success.</param>
        /// <param name="redirectToActionOnFailure">The redirect to action on failure.</param>
        /// <returns></returns>
        protected ActionResult HandleResult<T>(OperationResult<T> result, string redirectToActionOnSuccess, string redirectToActionOnFailure)
        {
            if (result.IsSuccess)
            {
                return RedirectToAction(redirectToActionOnSuccess);
            }
            else
            {
                ModelState.AddModelError(result.MainMessage.Code, result.MainMessage.Text);
                if (result.AssociatedMessages.Count<Message>() > 0)
                {
                    foreach (var item in result.AssociatedMessages)
                    {
                        ModelState.AddModelError(item.Code, item.Text);
                    }
                }
            }

            return View(redirectToActionOnFailure);
        }
    }
}
