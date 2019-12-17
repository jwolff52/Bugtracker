using System;

namespace Bugtracker.Models {
    public class TicketHistory {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser User { get; set; }
        public PropertyUpdated PropertyUpdated;
        public String OldValue { get; set; }
        public String NewValue { get; set; }
        public DateTime TimeUpdated { get; set; }
    }

    public enum PropertyUpdated {
        Title,
        Description,
        Assigned_Developers,
        Priority,
        Status,
        Type
    }
}