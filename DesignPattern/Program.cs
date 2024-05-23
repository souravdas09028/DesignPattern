using static DesignPattern.Customers;

namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CallStaticInstance();
            CallStaticCons();

            // static class and singletone class are quite similar but singletone class are more flexible
            //we will use singletone over static claas for these reasons
            /*
            State Management:
            Static Class: Does not maintain state across method calls. Suitable for stateless operations.
            Singleton Class: Can maintain state and is useful when state persistence across method 
            calls is required.

            Inheritance and Interfaces:
            Static Class: Cannot implement interfaces or be extended.
            Singleton Class: Can implement interfaces and be extended, providing more flexibility 
            and allowing the use of dependency injection.

            Initialization Control:
            Static Class: Initialized by the runtime when first accessed.
            Singleton Class: Allows more controlled and often lazy initialization, providing 
            better performance and resource management.

            Dependency Injection:
            Static Class: Not suitable for dependency injection because it cannot be 
            instantiated or passed around.
            Singleton Class: Suitable for dependency injection, enhancing testability and flexibility.
             */

            //CheckSimpleSingleTone();

            //check lock mechanism
            //Parallel.Invoke(() => CreatedObj1(), () => CreatedObj2());

            //check lock mechanism eager loading
            //Parallel.Invoke(() => CreatedEgarObj1(), () => CreatedEgarObj2());

            //var discount = GetDiscountByFactoryCls(1);
            //Console.WriteLine(discount);            

            Console.ReadLine();
        }

        private static decimal GetDiscountByFactoryCls(int custType)
        {
            ICustomer obj1 = CustomerFactory.CreateCustomer(custType);
            if (obj1 is SuperShop)
            {
                Console.WriteLine("Super Shop");
            }
            return obj1.GetDiscount();
        }

        private static void CreatedEgarObj1()
        {
            SingleToneEagerLoad obj1 = SingleToneEagerLoad.Getnstance();
            obj1.cost = 5;

            //return obj1;
        }

        private static void CreatedEgarObj2()
        {
            SingleToneEagerLoad obj2 = SingleToneEagerLoad.Getnstance();
            obj2.cost = 5;

            //return obj2;
        }

        private static void CreatedObj1()
        {
            SingleToneSimple obj1 = SingleToneSimple.Getnstance();
            obj1.cost = 5;

            //return obj1;
        }

        private static void CreatedObj2()
        {
            SingleToneSimple obj2 = SingleToneSimple.Getnstance();
            obj2.cost = 5;

            //return obj2;
        }

        private static void CheckSimpleSingleTone()
        {
            SingleToneSimple obj1 = SingleToneSimple.Getnstance();

            SingleToneSimple obj2 = SingleToneSimple.Getnstance();

            ////both same all prop are same and shared accross multiple thread / request
            //obj2.cost
            //obj1.cost

            ////call when it was public constructor
            //SingleToneSimple obj3 = new SingleToneSimple();
            //obj3.cost = 20;

            Console.WriteLine(obj2.cost == obj1.cost);
            Console.WriteLine(obj2 == obj1);
        }
        public static void CallStaticInstance()
        {
            //check static prop behaviour
            StaticInsClass obj1 = new StaticInsClass();
            StaticInsClass obj2 = new StaticInsClass();

            obj1.Print();
            obj1.Print();

            StaticInsClass obj3 = new StaticInsClass();
            obj2.Print();
            obj1.Print();

            StaticInsClass.counter = 1;
            obj3.Print();

            //Singletone.counter = 0;
            Console.WriteLine(obj2 == obj1);
        }
        private static void CallStaticCons()
        {
            //check static prop behaviour

            //static variables are called first then static constructor
            //then other variables -- if the costructor is static
            // static costructor is used to initialize static fields
            //other wise static fields are initialized when it is needed -- like lazy

            // field are initialized when object is created but properties are not
            //static constructor is called only once as like as static fields
            //static constructor and static fields are tied togather when one is called another is called also                     



            //public static int counter = 1;
            //public static int counter2 = 1;
            //public int counterExtrnl = 1;
            //public int prop1 { get; set; }
            //static StaticCons()
            //{
            //    counter++;
            //}
            //public void Print()
            //{
            //    counter++;
            //    Console.WriteLine(" " + counter + " Hello, World!");
            //    Console.WriteLine(" " + counterExtrnl + " Hello, World! extrnl");
            //}        


            StaticCons.counter = 0;
            StaticCons obj1 = new StaticCons();
            StaticCons obj2 = new StaticCons();
            obj1.counterExtrnl = 3;
            obj2.counterExtrnl = 5;

            obj1.Print();
            obj1.Print();
            obj2.Print();

            StaticCons.counter = 1;
            StaticCons obj3 = new StaticCons();

            obj2.Print();
            obj1.Print();

            //Singletone.counter = 0;
            Console.WriteLine(obj2 == obj1);
        }
    }
}
