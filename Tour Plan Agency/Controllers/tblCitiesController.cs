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
    public class tblCitiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblCities
        public ActionResult Index()
        {
            var tblHotels = db.tblHotels.Include(t => t.tblCity); 
            return View(db.tblCities.ToList());
        }

        // GET: tblCities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCity tblCity = db.tblCities.Find(id);
            if (tblCity == null)
            {
                return HttpNotFound();
            }
            return View(tblCity);
        }

        // GET: tblCities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCity tblCity, HttpPostedFileBase pic)
        {
            if (pic != null) { 
            string fullpath = Server.MapPath("~/Content/projectpic/" + pic.FileName);
            pic.SaveAs(fullpath);
            tblCity.City_image = "~/Content/projectpic/" + pic.FileName;
            }
                if (ModelState.IsValid)
                {
                    db.tblCities.Add(tblCity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            

            return View(tblCity);
        }

        // GET: tblCities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCity tblCity = db.tblCities.Find(id);
            if (tblCity == null)
            {
                return HttpNotFound();
            }
            return View(tblCity);
        }

        // POST: tblCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "City_ID,City_Name,City_Image")] tblCity tblCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCity);
        }

        // GET: tblCities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCity tblCity = db.tblCities.Find(id);
            if (tblCity == null)
            {
                return HttpNotFound();
            }
            return View(tblCity);
        }

        // POST: tblCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCity tblCity = db.tblCities.Find(id);
            db.tblCities.Remove(tblCity);
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
