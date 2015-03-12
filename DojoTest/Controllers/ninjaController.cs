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
    public class ninjaController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: ninja
        public ActionResult Index()
        {
            var ninjas = db.ninjas.Include(n => n.ninjaAttendance);
            return View(ninjas.ToList());
        }

        // GET: ninja/Details/5
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

        // GET: ninja/Create
        public ActionResult Create()
        {
            ViewBag.ninjaId = new SelectList(db.ninjaAttendances, "ninjaId", "ninjaId");
            return View();
        }

        // POST: ninja/Create
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
            return View(ninja);
        }

        // GET: ninja/Edit/5
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
            return View(ninja);
        }

        // POST: ninja/Edit/5
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
            return View(ninja);
        }

        // GET: ninja/Delete/5
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

        // POST: ninja/Delete/5
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
