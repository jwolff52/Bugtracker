using System;
using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class TicketComment {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser Commenter { get; set; }
        public string Message { get; set; }
        [Display(Name="Time Commented")]
        public DateTime TimeCommented { get; set; }
    }
}