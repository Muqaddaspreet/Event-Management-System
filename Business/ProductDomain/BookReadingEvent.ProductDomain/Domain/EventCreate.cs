using BookReadingEvent.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookReadingEvent.ProductDomain.Domain
{
   public  class EventCreate:DomainBase
    {
        public string Title { get; set; }
     
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string StartTime { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public string InviteByEmail { get; set; }
        public string Creator { get; set; }
    }
}
