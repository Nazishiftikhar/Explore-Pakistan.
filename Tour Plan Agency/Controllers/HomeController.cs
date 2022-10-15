using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tour_Plan_Agency.Models;
using Tour_Plan_Agency.Utills;

namespace Tour_Plan_Agency.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public object CurrentCustomer { get; private set; }

        public ActionResult IndexCustomer()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult login_Customers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login_Customers(tblCustomer customer)
        {
     
                tblCustomer cus= db.tblCustomers.Where(x => x.Customer_Email == customer.Customer_Email && x.Customer_Password == customer.Customer_Password).FirstOrDefault();
                if(cus!=null)
                {
                    CurrentUser.CurrentCustomer = cus;
                if (Session["cart"] == null)
                {
                    return RedirectToAction("Rooms","Home");
                }
                else
                {
                    return RedirectToAction("DisplayCart","Cart");
                }
                }
                else
                {
                    ViewBag.msg = "<script> alert(' Invalid Email And Password')</script>";
                }
            
            
            return View();
        }
        
        public ActionResult contactus()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            if (CurrentUser.CurrentCustomer == null)
            {
                return RedirectToAction("login_Customers", "home");
            }
            else
            {
                return View();
            }
            
            
        }
        public ActionResult Payment()
        {
            return View();
        }


        public ActionResult Cities()
        {
            
            return View();
        }
        public ActionResult Hotels( int? id)
        {
            if( id != null)
            {
                ViewData["cityid"] = id;
            }
              return View();
        }
        public ActionResult Rooms(int? id)
        {
            if (id != null)
            {
                ViewData["hotelid"] = id;
            }
            return View();
        }
          
        public ActionResult bookingstep3()
        {
            return View();
        }
        public ActionResult Login_Admin()
        {
            return View();
        }

        public ActionResult Location
            ()
        {
            return View();
        }public ActionResult car_rentals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(tblCustomer customer)
        {

            if (customer.Customer_Name == null || customer.Customer_Address == null || customer.Customer_Phone == null)
            {
                tblCustomer cus = db.tblCustomers.Where(x => x.Customer_Email == customer.Customer_Email && x.Customer_Password == customer.Customer_Password).FirstOrDefault();
                if (cus != null)
                {
                    CurrentUser.CurrentCustomer = cus;
                    return RedirectToAction("DisplayCart","Cart");
                }  
                else
                {
                    ViewBag.msg = "<script> alert(' Invalid Email And Password')</script>";
                }
            }
            if (ModelState.IsValid)
            {
                db.tblCustomers.Add(customer);
                db.SaveChanges();
                ViewBag.msg = "<script> alert(' Account is Created Sucessfully')</script>";
                return RedirectToAction("DisplayCart","Cart");
            }


            return View();
        }
        [HttpPost]
        public ActionResult Login_Admin(string email, string password)
        {
            db.tblAdmins.Where(x => x.Admin_Email == email && x.Admin_Password == password).Count();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        } public ActionResult BookingComplete()
        {
            return View();
        }
        public ActionResult cart()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult register()
        {
              return View();
        }

        [Obsolete]
        public ActionResult Booking( tblBookTour Book)
         {
            Book.Booking_Status = "Booked";
            Book.Booking_Type = "Sale";
            Book.Booking_Date = System. DateTime.Now;
            Book.Customer_FID = CurrentUser.CurrentCustomer.Customer_ID;
            Book.Availability_status = "Available" ;
            db.tblBookTours.Add(Book);
            db.SaveChanges();
            
            foreach (var item in (List<tblRoom>)Session["Cart"])
             {
                tblTour_Detail TD = new tblTour_Detail();
                TD.Room_FID = item.Room_ID;
                TD.Room_quantity = item.quantity;
                TD.Room_Price = item.Room_Price;
                TD.Booking_FID= Book.Booking_ID;
                db.tblTour_Detail.Add(TD);
                db.SaveChanges();
            }
            string EmailBody = "Your Booking has been Successfully!";
            EmailProvider.SendEmail(Book.tblCustomer.Customer_Email, "Book confirmation",EmailBody);
            TempData["Book"] = Session["Cart"];
            Session["Cart"] = null;       
              return RedirectToAction("BookingComplete");
        }

    }
}