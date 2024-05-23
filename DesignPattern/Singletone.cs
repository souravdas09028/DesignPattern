using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class SingleToneLazyLoadUsingLazy
    {
        //lazy loading using lazy  
        // Lazy initialization means that the object is not created until it is needed.
        private static readonly Lazy<SingleToneLazyLoadUsingLazy> _instance
            = new Lazy<SingleToneLazyLoadUsingLazy>(() => new SingleToneLazyLoadUsingLazy());

        public int cost = 0;
        private static int counter = 0;

        private SingleToneLazyLoadUsingLazy()
        {
            counter++;

            Console.WriteLine("Counter value : " + counter + "");
        }
        public static SingleToneLazyLoadUsingLazy Getnstance()
        {
            //for lazy loading using lazy
            return _instance.Value;
        }
    }

    public class SingleToneEagerLoad
    {
        //normal eager loading
        private static readonly SingleToneEagerLoad _instance = new SingleToneEagerLoad();
        public int cost = 0;
        private static int counter = 0;

        private SingleToneEagerLoad()
        {
            counter++;

            Console.WriteLine("Counter value : " + counter + "");
        }
        public static SingleToneEagerLoad Getnstance()
        {
            //no need for double check and locking as static is thread safe
            //and istance is already created
            //normal eager loading 
            return _instance;
        }
    }

    public class SingleToneSimple
    {
        private static SingleToneSimple _instance = null;
        public int cost = 0;
        private static int counter = 0;
        //lock object
        private static readonly object _itm = new int();

        private SingleToneSimple()
        {
            counter++;

            Console.WriteLine("Counter value : " + counter + "");
        }
        public static SingleToneSimple Getnstance()
        {
            //double check lock
            //only when instance is null then need to check for locking
            if (_instance == null)
            {
                //thread safety locking
                lock (_itm)
                {
                    //lazy loading
                    if (_instance == null)
                        _instance = new SingleToneSimple();
                }
            }

            return _instance;
        }
    }

    public class StaticInsClass
    {
        public static int counter = 1;

        public StaticInsClass()
        {
            counter++;
        }
        public void Print()
        {
            counter++;
            Console.WriteLine(" " + counter + " Hello, World!");
        }
    }

    public class StaticCons
    {
        public static int counter = 1;
        public static int counter2 = 1;
        public int counterExtrnl = 1;

        public int prop1 { get; set; }

        private static int? _birthDate;
        public static int? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        static StaticCons()
        {
            counter++;
        }
        //public StaticCons()
        //{
        //    counter++;
        //}
        public void Print()
        {
            counter++;
            Console.WriteLine(" " + counter + " Hello, World!");
            Console.WriteLine(" " + counterExtrnl + " Hello, World! extrnl");
        }
    }
}
