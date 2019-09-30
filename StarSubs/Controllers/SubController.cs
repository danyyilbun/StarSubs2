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
        public ActionResult Index(OrderManipulation order)
        {

            return View();
        }

    }
}