using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectorCSharp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ProjectorCSharp.DAL
{
    public class ProjectorContext:DbContext
    {

        public ProjectorContext(): base ("ProjectorContext")
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        

    }
}