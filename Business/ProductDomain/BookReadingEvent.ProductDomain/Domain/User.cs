using BookReadingEvent.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookReadingEvent.ProductDomain.Domain
{
    public class User:DomainBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string InvitedEvent { get; set; }
    }
}
