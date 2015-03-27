using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DojoTest;

namespace DojoTest.Controllers
{
    public class MentorsController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Mentors
        public ActionResult Index()
        {
            var mentors = db.mentors.Include(m => m.mentorAttendance);
            return View(mentors.ToList());
        }

        // GET: Mentors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mentor mentor = db.mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // GET: Mentors/Create
        public ActionResult Create()
        {
            ViewBag.mentorId = new SelectList(db.mentorAttendances, "mentorId", "mentorId");
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mentorId,forename,surname,bio,mentorUrl,dateJoined,active")] mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.mentors.Add(mentor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mentorId = new SelectList(db.mentorAttendances, "mentorId", "mentorId", mentor.mentorId);
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mentor mentor = db.mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            ViewBag.mentorId = new SelectList(db.mentorAttendances, "mentorId", "mentorId", mentor.mentorId);
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mentorId,forename,surname,bio,mentorUrl,dateJoined,active")] mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mentor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mentorId = new SelectList(db.mentorAttendances, "mentorId", "mentorId", mentor.mentorId);
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mentor mentor = db.mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mentor mentor = db.mentors.Find(id);
            db.mentors.Remove(mentor);
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
