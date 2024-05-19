using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Customers
    {
        public class RetailCustomer() : ICustomer
        {
            public int dicount { get; set; }
            public decimal GetDiscount()
            {
                return 10;
            }
        }

        public class SuperShop() : ICustomer
        {
            public int dicount { get; set; }
            public decimal GetDiscount()
            {
                return dicount * 2;
            }
        }

        public class WholeSaleCustomer() : ICustomer
        {
            public int dicount { get; set; }
            public decimal GetDiscount()
            {
                return dicount * 3;
            }
        }
    }
}
