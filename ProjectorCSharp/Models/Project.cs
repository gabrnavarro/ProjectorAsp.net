using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectorCSharp.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }

}