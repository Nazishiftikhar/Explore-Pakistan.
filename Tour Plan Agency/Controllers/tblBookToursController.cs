using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tour_Plan_Agency.Models;

namespace Tour_Plan_Agency.Controllers
{
    public class tblBookToursController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblBookTours
        public ActionResult Index()
        {
            var tblBookTours = db.tblBookTours.Include(t => t.tblCustomer);
            return View(tblBookTours.ToList());
        }

        // GET: tblBookTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookTour tblBookTour = db.tblBookTours.Find(id);
            if (tblBookTour == null)
            {
                return HttpNotFound();
            }
            return View(tblBookTour);
        }

        // GET: tblBookTours/Create
        public ActionResult Create()
        {
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Name");
            return View();
        }

        // POST: tblBookTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Booking_Date,Booking_Status,Booking_Type,Customer_FID,Availability_status")] tblBookTour tblBookTour)
        {
            if (ModelState.IsValid)
            {
                db.tblBookTours.Add(tblBookTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Name", tblBookTour.Customer_FID);
            return View(tblBookTour);
        }

        // GET: tblBookTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookTour tblBookTour = db.tblBookTours.Find(id);
            if (tblBookTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Name", tblBookTour.Customer_FID);
            return View(tblBookTour);
        }

        // POST: tblBookTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Booking_Date,Booking_Status,Booking_Type,Customer_FID,Availability_status")] tblBookTour tblBookTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBookTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Name", tblBookTour.Customer_FID);
            return View(tblBookTour);
        }

        // GET: tblBookTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookTour tblBookTour = db.tblBookTours.Find(id);
            if (tblBookTour == null)
            {
                return HttpNotFound();
            }
            return View(tblBookTour);
        }

        // POST: tblBookTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBookTour tblBookTour = db.tblBookTours.Find(id);
            db.tblBookTours.Remove(tblBookTour);
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
