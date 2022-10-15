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
    public class tblRoomsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblRooms
        public ActionResult Index()
        {
            var tblRooms = db.tblRooms.Include(t => t.tblHotel);
            return View(tblRooms.ToList());
        }

        // GET: tblRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoom tblRoom = db.tblRooms.Find(id);
            if (tblRoom == null)
            {
                return HttpNotFound();
            }
            return View(tblRoom);
        }

        // GET: tblRooms/Create
        public ActionResult Create()
        {
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name");
            return View();
        }

        // POST: tblRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Room_ID,Room_Name,No_Of_Person,Room_image,Hotel_FID")] tblRoom tblRoom)
        {
            if (ModelState.IsValid)
            {
                db.tblRooms.Add(tblRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblRoom.Hotel_FID);
            return View(tblRoom);
        }

        // GET: tblRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoom tblRoom = db.tblRooms.Find(id);
            if (tblRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblRoom.Hotel_FID);
            return View(tblRoom);
        }

        // POST: tblRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblRoom tblRoom , HttpPostedFileBase pic)
        {
            if (pic!= null)
            {
                string fullpath = Server.MapPath("~/Content/projectpic/" + pic.FileName);
                pic.SaveAs(fullpath);
                tblRoom.Room_image = "~/Content/projectpic/" + pic.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hotel_FID = new SelectList(db.tblHotels, "Hotel_ID", "Hotel_Name", tblRoom.Hotel_FID);
            return View(tblRoom);
        }

        // GET: tblRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoom tblRoom = db.tblRooms.Find(id);
            if (tblRoom == null)
            {
                return HttpNotFound();
            }
            return View(tblRoom);
        }

        // POST: tblRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRoom tblRoom = db.tblRooms.Find(id);
            db.tblRooms.Remove(tblRoom);
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
