using System;
using System.Collections.Generic;

namespace Bugtracker.Models {
    public class TrackerUser {
        public int ID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }

    public enum Role { 
        Admin,
        ProjectManager,
        Developer,
        Tester
    }
}