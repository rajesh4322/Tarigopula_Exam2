using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarigopula_Exam02.Hospital;
using Tarigopula_Exam02.Models;

namespace Tarigopula_Exam2.Controllers
{
    public class PhysicianController : Controller
    {
        private PhysicianContext db = new PhysicianContext();

        // GET: Physician
        public ActionResult Index()
        {
            return View(db.Physician.ToList());
        }

        // GET: Physician/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician physician = db.Physician.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // GET: Physician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Physician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhysicianID,LastName,FirstMidName,Age")] Physician physician)
        {
            if (ModelState.IsValid)
            {
                db.Physician.Add(physician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(physician);
        }

        // GET: Physician/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician physician = db.Physician.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: Physician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhysicianID,LastName,FirstMidName,Age")] Physician physician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(physician);
        }

        // GET: Physician/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician physician = db.Physician.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: Physician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Physician physician = db.Physician.Find(id);
            db.Physician.Remove(physician);
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
