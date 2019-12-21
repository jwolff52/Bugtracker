using System;
using System.ComponentModel.DataAnnotations;

namespace Bugtracker.Models {
    public class Login {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

       [Required]
       [DataType(DataType.Password)] 
       [Display(Name = "Password")]
       public string Password { get; set; }
    }
}