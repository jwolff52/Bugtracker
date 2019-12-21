using System;

namespace Bugtracker.Models {
    public class TicketAttachment {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int UploaderID { get; set; }
        public string Notes { get; set; }
        public string File_Location { get; set; }
    }
}