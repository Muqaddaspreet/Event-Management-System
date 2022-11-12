using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Models
{
    public class UserLogin
    {
      
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This Field is required")]
        public string EmailID { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters long.")]
       
        public string Password { get; set; }

        public string errormessage;
        
    }
}
