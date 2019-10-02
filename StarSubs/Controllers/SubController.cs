using BLL;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSubs.Controllers
{
    public class SubController : Controller
    {
        int tax = 15;
        Dictionary<string, double> type = new Dictionary<string, double>()
        {
            { "TheMichaelJackson", 1},{"ThePrince",2 },{"TheBackStreetBoys",3 },{"TheBeyonce",4 },{"TheMadonna",5 }
              
        };
        Dictionary<string, double> size = new Dictionary<string, double>()
        {
            { "OneHitWonder", 1 },{"BList",2 },{"AList",3 },{"Superstar",4}

        };
        Dictionary<string, double> deal = new Dictionary<string, double>()
        {
            { "None", 0 },{"DrinkAndChips",1.25 },{"DrinkAndCookies",2 }

        };
        // GET: Sub
        public ActionResult Index()
        {
            var order = new OrderManipulation
            {

                Types = Enum.GetValues(typeof(SubType)).Cast<SubType>().Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).AsEnumerable(),
                Sizes = Enum.GetValues(typeof(SubSize)).Cast<SubSize>().Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).AsEnumerable(),
                Deals = Enum.GetValues(typeof(MealDeal)).Cast<MealDeal>().Select(x => x.ToString()).ToList()
            };
            return View(order);
        }
        [HttpPost]
        public ActionResult Index(OrderManipulation orderMan)
        {
            var order = new OrderManipulation
            {

                Types = Enum.GetValues(typeof(SubType)).Cast<SubType>().Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).AsEnumerable(),
                Sizes = Enum.GetValues(typeof(SubSize)).Cast<SubSize>().Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).AsEnumerable(),
                Deals = Enum.GetValues(typeof(MealDeal)).Cast<MealDeal>().Select(x => x.ToString()).ToList()
            };
           
            TempData["type"] = orderMan.Type;
            TempData["size"] = orderMan.Size;
            TempData["deal"] = orderMan.Deal;
            TempData["ammount"] = orderMan.Ammount;
            TempData["mealDeal"] = deal[orderMan.Deal];
            TempData["Price"] = (type[orderMan.Type] * size[orderMan.Size]) * orderMan.Ammount;
 
            TempData["totalPrice"] = ((type[orderMan.Type.ToString()] 
                * size[orderMan.Size.ToString()]) + deal[orderMan.Deal]) 
                * orderMan.Ammount;
           

            double price;
            Double.TryParse(TempData["totalPrice"].ToString(),out price);

            TempData["tax"] =  (price * tax / 100);

            double tx;
            Double.TryParse(TempData["tax"].ToString(), out tx);

   
            double tb;
            if (Double.TryParse(Session["totalBought"].ToString(), out tb))
            { }


            double at;
            if (Double.TryParse(Session["AllTax"].ToString(), out at))
            { }


            if (tb != 0 && Session["allOrders"] != null && at != 0)
            {
                Session["totalBought"] = tb + price;
                Session["allOrders"] += "Order type :" + TempData["type"] +  "Order size:" + TempData["size"] +
                    "Deal Type:" + TempData["deal"]  + "Order Ammount:" + TempData["ammount"];
                Session["AllTax"] = at + tx;
            }
            else
            {
                Session["totalBought"] = 0;
                Session["allOrders"] = "";
                Session["AllTax"] = 0;
            }
            return RedirectToAction("Index","Home");
        }

    }
}