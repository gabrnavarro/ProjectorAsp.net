using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectorCSharp.Models
{
    public class AssignViewModel
    {
        public List <Person> Persons { get; set; }
        public List <Project> Projects { get; set; }
        public List <Assignment> Assignments {get; set;}

    }
}