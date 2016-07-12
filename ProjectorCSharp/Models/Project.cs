using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectorCSharp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}