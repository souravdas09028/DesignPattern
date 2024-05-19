using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Customers;

namespace DesignPattern
{
    public static class CustomerFactory
    {
        public static ICustomer CreateCustomer(int custType)
        {
            //if this is inside it will return new instance and it is thread safe
            ICustomer cust = null;

            if (custType == 0)
            {
                cust = new SuperShop { dicount = 20 };
            }

            else if (custType == 1)
            {
                cust = new WholeSaleCustomer { dicount = 20 };
            }

            return cust;
        }
    }
}
