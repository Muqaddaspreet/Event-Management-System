using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.DTOs
{
    public class CommentDTO
    {
        public int CommentID { get; set; }
        public string Comment1 { get; set; }
        public Nullable<int> EventID { get; set; }
        public string CreatorID { get; set; }

        public string Email { get; set; }
        public string EventName { get; set; }
    }
}
