using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookReadingEvent.Core.WebMVC
{
    public class ExceptionViewModel
    {
        [Display(Name = "Controller Name")]
        [Required(ErrorMessage = "Please Enter Controller Name")]
        public string ControllerName { get; set; }

        [Display(Name = "Action Name")]
        [Required(ErrorMessage = "Please Enter Action Name")]
        public string ActionName { get; set; }

        [Display(Name = "Controller Name")]
        [Required(ErrorMessage = "Please Enter Exception Details")]
        public Exception ExceptionDetails { get; set; }

        public ExceptionViewModel(Exception exception, string controllerName, string actionName)
        {
            ExceptionDetails = exception;
            ControllerName = controllerName;
            ActionName = actionName;

        }
    }
}
