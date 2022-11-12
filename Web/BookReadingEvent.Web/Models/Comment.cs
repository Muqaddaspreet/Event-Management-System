using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Comment1 { get; set; }
        public Nullable<int> EventID { get; set; }

        public string CreatorID { get; set; }
 
        public string Email{ get; set; }

        public string EventName { get; set; }

    }
}
