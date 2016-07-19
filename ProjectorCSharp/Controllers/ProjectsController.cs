using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectorCSharp.DAL;
using ProjectorCSharp.Models;
using System.Data.SqlClient;

namespace ProjectorCSharp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ProjectorContext db = new ProjectorContext();

        // GET: Projects
        public ActionResult Index()
        {
            

            return View(db.Projects.ToList());
        }

        public ActionResult Assign(int id)
        {
            AssignViewModel vm = new AssignViewModel();
            vm.Persons = db.People.ToList();
            vm.Projects = db.Projects.ToList();
            vm.Assignments = db.Assignments.ToList();
            int pageid = id;
            ViewBag.id = pageid;
            var persons = new List<Person>();
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Asus\Documents\Visual Studio 2015\Projects\ProjectorCSharp\ProjectorCSharp\App_Data\ProjectorContext.mdf';Integrated Security=True;Connect Timeout=30; Initial Catalog =ProjectorContext"))
            {
                using (SqlCommand cmd = new SqlCommand("Select assign.ProjectID, person1.Firstname, person1.Lastname from Assignments as assign inner join People as person1 ON person1.ID=assign.PersonID where assign.ProjectID = '" + pageid+ "'", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Person p = new Person();
                                p.ID = reader.GetInt32(reader.GetOrdinal("ProjectID"));
                                p.Firstname = reader.GetString(reader.GetOrdinal("Firstname"));
                                p.Lastname = reader.GetString(reader.GetOrdinal("Lastname"));
                                persons.Add(p);
                            }
                        }
                    }
                }
            }
            vm.Persons = persons;
            return View(vm);
        }
        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,Name,Budget,Remarks")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Name,Budget,Remarks")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
