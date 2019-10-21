using System;

namespace ConsoleApp1
{
    interface IMyInterface
    {
        string MyFunc();
    }

    class Product
    {
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

        public Product()
        {
            OrganizationName = "NoName organization";
            ProductName = "NoName product";
        }

        public Product(string organization, string product)
        {
            OrganizationName = organization;
            ProductName = product;
        }

        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return ((this.OrganizationName == product.OrganizationName) && (this.ProductName == product.ProductName));
        }

        public override int GetHashCode()
        {
            return OrganizationName.GetHashCode() + ProductName.GetHashCode();
        }

        public override string ToString()
        {
            return this.OrganizationName + " " + this.ProductName;
        }
    }

    class Tech : Product
    {
        public string ManufacturerName { get; set; }
        public Tech() : base()
        {
            ManufacturerName = "NoName Manufacturer";
        }

        public Tech(string organization, string product, string manufacturer) : base(organization, product)
        {
            ManufacturerName = manufacturer;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.ManufacturerName;
        }
    }

    abstract class Computer : Tech
    {
        public string OS { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.OS;
        }

        public Computer() : base()
        {
            OS = "NoName OS";
        }

        public Computer(string organization, string product, string manufacturer, string os) : base(organization, product, manufacturer)
        {
            OS = os;
        }

        public abstract string MyFunc();
    }

    sealed class Printer : Tech
    {
        public string IncType { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.IncType;
        }

        public Printer() : base()
        {
            IncType = "NoName Inc";
        }

        public Printer(string organization, string product, string manufacturer, string inc) : base(organization, product, manufacturer)
        {
            IncType = inc;
        }
    }

    class Scanner : Tech
    {
        public string DocType { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.DocType;
        }

        public Scanner() : base()
        {
            DocType = "NoName DocType";
        }

        public Scanner(string organization, string product, string manufacturer, string doc) : base(organization, product, manufacturer)
        {
            DocType = doc;
        }
    }

    class Tablet : Computer, IMyInterface
    {
        public string Resolution { get; set; }
        public override string MyFunc()
        {
            return "Переопределение";
        }
        string IMyInterface.MyFunc()
        {
            return "Реализация функции интерфейса";
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Resolution;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("123", "213");
            Tech tech = new Tech("456", "789", "456789");
            Tablet tablet = new Tablet();
            IMyInterface myInterface = tablet;

            Console.WriteLine(product.ToString());
            Console.WriteLine(tech.ToString());
            Console.WriteLine(tablet.MyFunc());
            Console.WriteLine(myInterface.MyFunc());
            Console.WriteLine($"myInterface is IMyInterface = {myInterface is IMyInterface}");
            Console.WriteLine($"myInterface is Tabet = {myInterface is Tablet}");
        }
    }
}
