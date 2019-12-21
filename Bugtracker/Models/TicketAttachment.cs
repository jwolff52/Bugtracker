using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class TicketAttachment {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser Uploader { get; set; }
        public string Notes { get; set; }
        [Display(Name="File")]
        public string FileLocation { get; set; }
    }
}