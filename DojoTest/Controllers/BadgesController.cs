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
    public class BadgesController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Badges
        public ActionResult Index()
        {
            return View(db.badges.ToList());
        }

        // GET: Badges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            badge badge = db.badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // GET: Badges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Badges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "badgeId,name,description,badgeStepId,active")] badge badge)
        {
            if (ModelState.IsValid)
            {
                db.badges.Add(badge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(badge);
        }

        // GET: Badges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            badge badge = db.badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "badgeId,name,description,badgeStepId,active")] badge badge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(badge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(badge);
        }

        // GET: Badges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            badge badge = db.badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            badge badge = db.badges.Find(id);
            db.badges.Remove(badge);
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
