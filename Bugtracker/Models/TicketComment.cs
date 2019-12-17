using System;

namespace Bugtracker.Models {
    public class TicketComment {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser Commenter { get; set; }
        public string Message { get; set; }
        public DateTime TimeCommented { get; set; }
    }
}