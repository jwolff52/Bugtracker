using System;
using System.Collections.Generic;

namespace Bugtracker.Models {
    public class Ticket {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TicketUser> AssignedDevelopers { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Type Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public List<TicketHistory> HistoryIDs { get; set; }
        public List<TicketComment> CommentIDs { get; set; }
        public List<TicketAttachment> AttachmentIDs { get; set; }
    }

    public class TicketUser {
        public int ID {get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
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