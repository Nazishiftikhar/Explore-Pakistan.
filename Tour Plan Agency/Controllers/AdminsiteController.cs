using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_Plan_Agency.Models;
using Tour_Plan_Agency.Utills;

namespace Tour_Plan_Agency.Controllers
{
    public class AdminsiteController : Controller
    {
        Model1 db=new Model1();

        public EntityState EntiState { get; private set; }

        // GET: Adminsite
        public ActionResult NewBookings()
        {
           var Bookinglist= db.tblBookTours.Where(x => x.Booking_Status == "Booked").OrderByDescending(x=>x.Booking_Date).ToList();
            return View(Bookinglist);
        }
        public ActionResult Invoice(int id)
        {
            var Invoicedata= db.tblBookTours.Where(x => x.Booking_ID == id).FirstOrDefault();
            return View(Invoicedata);
        } 
        public ActionResult SendToProceed(int id)
        {
            var Bookdata = db.tblBookTours.Find(id);
            Bookdata.Booking_Status = "Proceed";
            db.Entry(Bookdata).State = EntityState.Modified;
            db.SaveChanges();
            EmailProvider.SendEmail(Bookdata.tblCustomer.Customer_Email, "Booking Update",
               " Your Booking is now proceed");
            TempData["msg"] = "<script> alert(' your booking no" + id + " is now  proceed booking list ') </Script>";
            return RedirectToAction("NewBookings");
        }
    }
}
