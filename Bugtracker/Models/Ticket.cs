using System;
using System.Collections.Generic;

namespace Bugtracker.Models {
    public class Ticket {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TicketUser> AssignedDevelopers { get; set; }
        public TrackerUser Creator { get; set; }
        public Project Project { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Type Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public List<TicketHistory> History { get; set; }
        public List<TicketComment> Comments { get; set; }
        public List<TicketAttachment> Attachments { get; set; }
    }

    public class TicketUser {
        public int ID {get; set; }
        public Ticket Ticket { get; set; }
        public TrackerUser User { get; set; }
    }

    public enum Priority {
        High,
        Medium,
        Low,
    }
    public enum Status {
        Open,
        In_Progress,
        Closed,
        More_Info
    }
    public enum Type {
        Bug,
        Suggestion
    }
}