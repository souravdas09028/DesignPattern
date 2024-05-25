using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static DesignPattern.Customers;

namespace DesignPattern
{
    public static class FactoryWithUnity
    {
        static UnityContainer container = new UnityContainer();
        static FactoryWithUnity()
        {
            container.RegisterType<ICustomer, WholeSaleCustomer>("0");
            container.RegisterType<ICustomer, SuperShop>("1");
            container.RegisterType<ICustomer, RetailCustomer>("2");
        }

        public static ICustomer CreateFromContainer(int custType)
        {
            //need to clone other wise it would send same reference for all
            return container.Resolve<ICustomer>(custType.ToString());
        }
    }
}
