using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.DTOs
{
    public class CreateEventDTO
    {
        public int EventId { get; set; }
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
