using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class Project {
        public int ID {  get; set; }
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Description { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set;}
        [Display(Name = "Assigned Users")]
        public List<ProjectUser> AssignedUsers { get; set; }
        public List<Ticket> Tickets { get; set; }
    }

    public class ProjectUser {
        public int ID {get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
    }
}