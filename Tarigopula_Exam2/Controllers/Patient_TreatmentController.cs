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
    public class Patient_TreatmentController : Controller
    {
        private PhysicianContext db = new PhysicianContext();

        // GET: Patient_Treatment
        public ActionResult Index()
        {
            var patient_Treatment = db.Patient_Treatment.Include(p => p.Physician).Include(p => p.Treatment);
            return View(patient_Treatment.ToList());
        }

        // GET: Patient_Treatment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Treatment patient_Treatment = db.Patient_Treatment.Find(id);
            if (patient_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(patient_Treatment);
        }

        // GET: Patient_Treatment/Create
        public ActionResult Create()
        {
            ViewBag.PhysicianID = new SelectList(db.Physician, "PhysicianID", "LastName");
            ViewBag.TreatmentID = new SelectList(db.Treatment, "TreatmentID", "Title");
            return View();
        }

        // POST: Patient_Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Patient_TreatmentID,TreatmentID,PhysicianID,Patient_Treatment_Date")] Patient_Treatment patient_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Patient_Treatment.Add(patient_Treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhysicianID = new SelectList(db.Physician, "PhysicianID", "LastName", patient_Treatment.PhysicianID);
            ViewBag.TreatmentID = new SelectList(db.Treatment, "TreatmentID", "Title", patient_Treatment.TreatmentID);
            return View(patient_Treatment);
        }

        // GET: Patient_Treatment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Treatment patient_Treatment = db.Patient_Treatment.Find(id);
            if (patient_Treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhysicianID = new SelectList(db.Physician, "PhysicianID", "LastName", patient_Treatment.PhysicianID);
            ViewBag.TreatmentID = new SelectList(db.Treatment, "TreatmentID", "Title", patient_Treatment.TreatmentID);
            return View(patient_Treatment);
        }

        // POST: Patient_Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Patient_TreatmentID,TreatmentID,PhysicianID,Patient_Treatment_Date")] Patient_Treatment patient_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhysicianID = new SelectList(db.Physician, "PhysicianID", "LastName", patient_Treatment.PhysicianID);
            ViewBag.TreatmentID = new SelectList(db.Treatment, "TreatmentID", "Title", patient_Treatment.TreatmentID);
            return View(patient_Treatment);
        }

        // GET: Patient_Treatment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Treatment patient_Treatment = db.Patient_Treatment.Find(id);
            if (patient_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(patient_Treatment);
        }

        // POST: Patient_Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient_Treatment patient_Treatment = db.Patient_Treatment.Find(id);
            db.Patient_Treatment.Remove(patient_Treatment);
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
