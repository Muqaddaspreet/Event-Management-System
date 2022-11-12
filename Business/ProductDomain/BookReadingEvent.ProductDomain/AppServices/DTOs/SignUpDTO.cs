using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.DTOs
{
    public class SignUpDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailID { get; set; }
        public string Password { get; set; }
        public string InvitedEvent { get; set; }
    }
}
