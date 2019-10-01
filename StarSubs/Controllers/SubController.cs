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
            { " TheMichaelJackson", 1},{"ThePrince",2 },{"TheBackStreetBoys",3 },{"TheBeyonce",4 },{"TheMadonna",5 }

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
            TempData["mealDeal"] = deal[orderMan.Deal];
            TempData["Price"] = (type[orderMan.Type] * size[orderMan.Size]);
            TempData["Cost"] = (type[orderMan.Type] * size[orderMan.Size]);
            TempData["totalPrice"] = (type[orderMan.Type] * size[orderMan.Size]) + deal[orderMan.Deal];


            double price;
            Double.TryParse(TempData["totalPrice"].ToString(),out price);

            TempData["tax"] =  price * tax / 100;

            double tx;
            Double.TryParse(TempData["tax"].ToString(), out tx);
            
            Double.TryParse(TempData["totalPrice"].ToString(), out price);

            TempData["totalDue"] = (tx + price);
            return RedirectToAction("Index3");
        }
        public ActionResult Index3()
        {
            ViewBag.type = TempData["type"];
            ViewBag.size = TempData["size"];
            ViewBag.deal = TempData["deal"];

            double dm;
            Double.TryParse(TempData["mealDeal"].ToString(), out dm);
            ViewBag.mealDeal = dm;

            double pc;
             Double.TryParse(TempData["Price"].ToString(), out pc);
            ViewBag.Price = pc;

            double cost;
            Double.TryParse(TempData["Cost"].ToString(), out cost);
            ViewBag.Cost = cost;


            double tpc;
            Double.TryParse(TempData["totalPrice"].ToString(), out tpc);
            ViewBag.totalPrice = tpc;

            double tx;
            Double.TryParse(TempData["tax"].ToString(), out tx);
            ViewBag.tax = tx;

            double td;
            Double.TryParse(TempData["totalDue"].ToString(), out td);
            ViewBag.totalDue = td;

            return View();
        }
    }
}