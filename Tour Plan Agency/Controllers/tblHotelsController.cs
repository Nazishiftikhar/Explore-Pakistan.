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
    public class tblHotelsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblHotels
        public ActionResult Index()
        {
            var tblHotels = db.tblHotels.Include(t => t.tblCity);
            return View(tblHotels.ToList());
        }

        // GET: tblHotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotel tblHotel = db.tblHotels.Find(id);
            if (tblHotel == null)
            {
                return HttpNotFound();
            }
            return View(tblHotel);
        }

        // GET: tblHotels/Create
        public ActionResult Create()
        {
            ViewBag.City_FID = new SelectList(db.tblCities, "City_ID", "City_Name");
            return View();
        }

        // POST: tblHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblHotel tblHotel, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/Content/projectpic/" + pic.FileName);
                pic.SaveAs(fullpath);
                tblHotel.Hotel_Image = "~/Content/projectpic/" + pic.FileName;
            }
              if (ModelState.IsValid)
            {
                db.tblHotels.Add(tblHotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_FID = new SelectList(db.tblCities, "City_ID", "City_Name", tblHotel.City_FID);
            return View(tblHotel);
        }

        // GET: tblHotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotel tblHotel = db.tblHotels.Find(id);
            if (tblHotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_FID = new SelectList(db.tblCities, "City_ID", "City_Name", tblHotel.City_FID);
            return View(tblHotel);
        }

        // POST: tblHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblHotel tblHotel,HttpPostedFileBase pic)
        { 
            if(pic!=null )
            {
                string fullpath = Server.MapPath("~/Content/projectpic/" + pic.FileName);
                pic.SaveAs(fullpath);
                tblHotel.Hotel_Image = "~/Content/projectpic/" + pic.FileName;
            }

               if (ModelState.IsValid)
            {
                db.Entry(tblHotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_FID = new SelectList(db.tblCities, "City_ID", "City_Name", tblHotel.City_FID);
            return View(tblHotel);
        }

        // GET: tblHotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHotel tblHotel = db.tblHotels.Find(id);
            if (tblHotel == null)
            {
                return HttpNotFound();
            }
            return View(tblHotel);
        }

        // POST: tblHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblHotel tblHotel = db.tblHotels.Find(id);
            db.tblHotels.Remove(tblHotel);
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
