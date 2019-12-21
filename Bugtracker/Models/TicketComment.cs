using System;

namespace Bugtracker.Models {
    public class TicketComment {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int CommenterID { get; set; }
        public string Message { get; set; }
        public DateTime TimeCommented { get; set; }
    }
}