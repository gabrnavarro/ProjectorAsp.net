using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectorCSharp.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int PersonID { get; set; }

        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }

    }
}