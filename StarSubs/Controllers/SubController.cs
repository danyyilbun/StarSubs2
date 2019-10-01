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


            ViewBag.type = orderMan.Type;
            ViewBag.size = orderMan.Size;
            ViewBag.deal = orderMan.Deal;
            ViewBag.mealDeal = deal[orderMan.Deal];
            ViewBag.Price = (type[orderMan.Type] * size[orderMan.Size]);
            ViewBag.Cost = (type[orderMan.Type] * size[orderMan.Size]);
            ViewBag.totalPrice = (type[orderMan.Type] * size[orderMan.Size]) + deal[orderMan.Deal];
            ViewBag.tax = ViewBag.totalPrice * tax / 100;
            ViewBag.totalDue = ViewBag.tax + ViewBag.totalPrice;
            return View(order);
        }

    }
}