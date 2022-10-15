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
    public class tblWebServicesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblWebServices
        public ActionResult Index()
        {
            return View(db.tblWebServices.ToList());
        }

        // GET: tblWebServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWebService tblWebService = db.tblWebServices.Find(id);
            if (tblWebService == null)
            {
                return HttpNotFound();
            }
            return View(tblWebService);
        }

        // GET: tblWebServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblWebServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WServices_ID,WServices_Name,WServices_Price,WServices_Description")] tblWebService tblWebService)
        {
            if (ModelState.IsValid)
            {
                db.tblWebServices.Add(tblWebService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblWebService);
        }

        // GET: tblWebServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWebService tblWebService = db.tblWebServices.Find(id);
            if (tblWebService == null)
            {
                return HttpNotFound();
            }
            return View(tblWebService);
        }

        // POST: tblWebServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WServices_ID,WServices_Name,WServices_Price,WServices_Description")] tblWebService tblWebService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWebService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblWebService);
        }

        // GET: tblWebServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWebService tblWebService = db.tblWebServices.Find(id);
            if (tblWebService == null)
            {
                return HttpNotFound();
            }
            return View(tblWebService);
        }

        // POST: tblWebServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWebService tblWebService = db.tblWebServices.Find(id);
            db.tblWebServices.Remove(tblWebService);
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
