using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Loggers
    {
        [Key]
        public long idloggers { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression("^([^a-zA-Z])+$", ErrorMessage = "Names should have at least 2 characters")]
        public string fname { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression("^([^a-zA-Z])+$", ErrorMessage = "Names should have at least 2 characters")]
        public string lname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string password { get; set; }
        [Required]
        public DateTime updated_at { get; set; }
        [Required]
        public DateTime created_at { get; set; }
    }
}