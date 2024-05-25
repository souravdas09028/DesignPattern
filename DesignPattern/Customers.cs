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

            public ICustomer Clone()
            {
                return (ICustomer)this.MemberwiseClone();
            }

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

            public ICustomer Clone()
            {
                return (ICustomer)this.MemberwiseClone();
            }
        }

        public class WholeSaleCustomer() : ICustomer
        {
            public int dicount { get; set; }
            public decimal GetDiscount()
            {
                return dicount * 3;
            }

            public ICustomer Clone()
            {
                return (ICustomer)this.MemberwiseClone();
            }
        }
    }
}
