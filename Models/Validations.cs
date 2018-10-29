using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Validations
    {
        [Key]
        public long idloggers { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression("^([a-zA-Z])+$", ErrorMessage = "Names cannot be numbers")]
        public string fname { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression("^([a-zA-Z])+$", ErrorMessage = "Names cannot be numbers")]
        public string lname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters")]
        public string password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The passwords do not match.")]
        public string passconfirm { get; set; }
    }
}