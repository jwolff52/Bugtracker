using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class Ticket {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<TicketUser> AssignedDevelopers { get; set; }
        [Required]
        public TrackerUser User { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Type Type { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date Updated")]
        public DateTime DateUpdated { get; set; }

        public List<TicketHistory> Historys { get; set; }
        public List<TicketComment> Comments { get; set; }
        public List<TicketAttachment> Attachments { get; set; }
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