using System;
using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class TicketHistory {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser User { get; set; }
        [Display(Name="Property Updated")]
        public PropertyUpdated PropertyUpdated;
        [Display(Name="Old Value")]
        public String OldValue { get; set; }
        [Display(Name="New Value")]
        public String NewValue { get; set; }
        [Display(Name="Date Updated")]
        public DateTime DateUpdated { get; set; }
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