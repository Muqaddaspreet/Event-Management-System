using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.DTOs
{
    public class LoginDTO
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}
