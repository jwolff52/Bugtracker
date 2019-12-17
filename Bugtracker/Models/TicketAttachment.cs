using System;

namespace Bugtracker.Models {
    public class TicketAttachment {
        public int ID { get; set; }
        public Ticket ticket { get; set; }
        public TrackerUser Uploader { get; set; }
        public string Notes { get; set; }
        public string File_Location { get; set; }
    }
}