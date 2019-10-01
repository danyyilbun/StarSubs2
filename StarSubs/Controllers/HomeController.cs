using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSubs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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