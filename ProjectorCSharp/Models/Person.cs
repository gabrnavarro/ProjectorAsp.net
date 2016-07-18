using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectorCSharp.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Field must be alpha.") ]
        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5)]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Field must be alphanumeric with no spaces.")]
        [StringLength(11, MinimumLength = 7)]
        public string Password { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

    }
}