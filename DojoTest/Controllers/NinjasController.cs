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
    public class NinjasController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Ninjas
        public ActionResult Index()
        {
            var ninjas = db.ninjas.Include(n => n.ninjaAttendance).Include(n => n.dojoClass);
            return View(ninjas.ToList());
        }

        // GET: Ninjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ninja ninja = db.ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // GET: Ninjas/Create
        public ActionResult Create()
        {
            ViewBag.ninjaId = new SelectList(db.ninjaAttendances, "ninjaId", "ninjaId");
            ViewBag.classId = new SelectList(db.dojoClasses, "classId", "className");
            return View();
        }

        // POST: Ninjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ninjaId,ninjaName,classId,bio,joined,websiteUrl,active,DOB")] ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.ninjas.Add(ninja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ninjaId = new SelectList(db.ninjaAttendances, "ninjaId", "ninjaId", ninja.ninjaId);
            ViewBag.classId = new SelectList(db.dojoClasses, "classId", "className", ninja.classId);
            return View(ninja);
        }

        // GET: Ninjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ninja ninja = db.ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ninjaId = new SelectList(db.ninjaAttendances, "ninjaId", "ninjaId", ninja.ninjaId);
            ViewBag.classId = new SelectList(db.dojoClasses, "classId", "className", ninja.classId);
            return View(ninja);
        }

        // POST: Ninjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ninjaId,ninjaName,classId,bio,joined,websiteUrl,active,DOB")] ninja ninja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ninja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ninjaId = new SelectList(db.ninjaAttendances, "ninjaId", "ninjaId", ninja.ninjaId);
            ViewBag.classId = new SelectList(db.dojoClasses, "classId", "className", ninja.classId);
            return View(ninja);
        }

        // GET: Ninjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ninja ninja = db.ninjas.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }

        // POST: Ninjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ninja ninja = db.ninjas.Find(id);
            db.ninjas.Remove(ninja);
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
