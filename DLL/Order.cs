using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Order
    {
        public SubType Type { get; set; }
        public SubSize Size { get; set; }
        public MealDeal Deal { get; set; }
    }
}
