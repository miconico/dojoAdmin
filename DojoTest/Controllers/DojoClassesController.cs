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
    public class DojoClassesController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: DojoClasses
        public ActionResult Index()
        {
            var dojoClasses = db.dojoClasses.Include(d => d.mentor);
            return View(dojoClasses.ToList());
        }

        // GET: DojoClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dojoClass dojoClass = db.dojoClasses.Find(id);
            if (dojoClass == null)
            {
                return HttpNotFound();
            }
            return View(dojoClass);
        }

        // GET: DojoClasses/Create
        public ActionResult Create()
        {
            ViewBag.mentorId = new SelectList(db.mentors, "mentorId", "forename");
            return View();
        }

        // POST: DojoClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classId,className,classDesc,mentorId,dateCommenced,classUrl,active")] dojoClass dojoClass)
        {
            if (ModelState.IsValid)
            {
                db.dojoClasses.Add(dojoClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mentorId = new SelectList(db.mentors, "mentorId", "forename", dojoClass.mentorId);
            return View(dojoClass);
        }

        // GET: DojoClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dojoClass dojoClass = db.dojoClasses.Find(id);
            if (dojoClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.mentorId = new SelectList(db.mentors, "mentorId", "forename", dojoClass.mentorId);
            return View(dojoClass);
        }

        // POST: DojoClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classId,className,classDesc,mentorId,dateCommenced,classUrl,active")] dojoClass dojoClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dojoClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mentorId = new SelectList(db.mentors, "mentorId", "forename", dojoClass.mentorId);
            return View(dojoClass);
        }

        // GET: DojoClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dojoClass dojoClass = db.dojoClasses.Find(id);
            if (dojoClass == null)
            {
                return HttpNotFound();
            }
            return View(dojoClass);
        }

        // POST: DojoClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dojoClass dojoClass = db.dojoClasses.Find(id);
            db.dojoClasses.Remove(dojoClass);
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
