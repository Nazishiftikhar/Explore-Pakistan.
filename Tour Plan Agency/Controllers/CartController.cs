using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_Plan_Agency.Models;
using Tour_Plan_Agency.Utills;

namespace Tour_Plan_Agency.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        public ActionResult AddToCart(int id)
        {
            List<tblRoom> Cartlist = new List<tblRoom>();
            List<tblRoom> cartlist = Cartlist;
            if (Session["cart"] != null)
            {
                cartlist = (List<tblRoom>)Session["cart"];
            }
            tblRoom existingroom = cartlist.Where(x => x.Room_ID == id).FirstOrDefault();
            if (existingroom != null)
            {
                existingroom.quantity++;
            }
            else { 
            tblRoom tblRoom = db.tblRooms.Where(x => x.Room_ID == id).FirstOrDefault();
            tblRoom.quantity = 1;
            cartlist.Add(tblRoom);
            }
            Session["cart"] = cartlist;
            return RedirectToAction("DisplayCart");
        }

        public ActionResult DisplayCart()
        {

            return View();
        }
            
       
        public ActionResult RemoveFromCart(int id)
        {
            List<tblRoom>list=new List<tblRoom>();
            list= (List<tblRoom>) Session["cart"];
            list.RemoveAt(id); 
            Session["Cart"]=list;  

            return RedirectToAction("DisplayCart");
        }
       public ActionResult PlusToCart(int id)
        {
            List<tblRoom>list=new List<tblRoom>();
            list= (List<tblRoom>) Session["cart"];
            list[id].quantity++; 
            Session["Cart"]=list;  

            return RedirectToAction("DisplayCart");
        }
        public ActionResult MinusFromCart(int id)
        {
            List<tblRoom>list=new List<tblRoom>();
            list= (List<tblRoom>) Session["cart"];
            list[id].quantity--;
            if (list[id].quantity < 1)
            {
                list.RemoveAt(id); 
            }
            Session["Cart"]=list;  

            return RedirectToAction("DisplayCart");
        }
        public ActionResult OrderBooked(tblBookTour bookTour)
        {
            return View();
        }


    }
}