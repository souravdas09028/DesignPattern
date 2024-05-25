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
        static Dictionary<int, ICustomer> container = new Dictionary<int, ICustomer>();
        static CustomerFactory()
        {
            container.Add(0, new SuperShop());
            container.Add(1, new WholeSaleCustomer());
        }
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

        public static ICustomer CreateFromContainer(int custType)
        {
            //need to clone other wise it would send same reference for all
            return container[custType].Clone();
        }
    }
}
