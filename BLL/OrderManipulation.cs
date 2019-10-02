using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class OrderManipulation
    {
        public string Type { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }


        public string Size { get; set; }
        public IEnumerable<SelectListItem> Sizes { get; set; }


        public string Deal { get; set; }
        public List<string> Deals { get; set; }

        public int Ammount { get; set; }
    }
}
