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
    public class tblHotelServicesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblHotelServices
        public ActionResult Index()
        {
            var tblHotelServices = db.tblHotelServices.Include(t => t.tblHotel);
            return View(tblHotelServices.ToList());
        }

        // GET: tblHotelServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotelService tblHotelService = db.tblHotelServices.Find(id);
            if (tblHotelService == null)
            {
                return HttpNotFound();
            }
            return View(tblHotelService);
        }

        // GET: tblHotelServices/Create
        public ActionResult Create()
        {
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name");
            return View();
        }

        // POST: tblHotelServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_ID,Service_Name,Service_Price,Hotel_FID")] tblHotelService tblHotelService)
        {
            if (ModelState.IsValid)
            {
                db.tblHotelServices.Add(tblHotelService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblHotelService.Hotel_FID);
            return View(tblHotelService);
        }

        // GET: tblHotelServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotelService tblHotelService = db.tblHotelServices.Find(id);
            if (tblHotelService == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblHotelService.Hotel_FID);
            return View(tblHotelService);
        }

        // POST: tblHotelServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_ID,Service_Name,Service_Price,Hotel_FID")] tblHotelService tblHotelService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblHotelService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblHotelService.Hotel_FID);
            return View(tblHotelService);
        }

        // GET: tblHotelServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotelService tblHotelService = db.tblHotelServices.Find(id);
            if (tblHotelService == null)
            {
                return HttpNotFound();
            }
            return View(tblHotelService);
        }

        // POST: tblHotelServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblHotelService tblHotelService = db.tblHotelServices.Find(id);
            db.tblHotelServices.Remove(tblHotelService);
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
