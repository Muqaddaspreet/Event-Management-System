using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Title { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This Field is required")]
        public DateTime Date { get; set; }
        [DisplayName("Location")]
        [Required(ErrorMessage = "This Field is required")]
        public string Location { get; set; }
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "This Field is required")]
        public string StartTime { get; set; }
        [DisplayName("Event Type")]
        public string Type { get; set; }
        [DisplayName("Duration(In Hours)")]
        public int Duration { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Other Details")]
        public string OtherDetails { get; set; }

        [DisplayName("Invite By Email")]
        public string InviteByEmail { get; set; }
        public string Creator { get; set; }

    }
}
