using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            byte c = 8;
            double num2 = 2.4;
            int byteToInt = c;
            int doubleToInt = (int)num2;
            int? x = null;
            int y = x ?? 2;

            object o = number;
            int unboxed = (int)o;

            string name = "Stepan";
            string str = "String";
            string numToString = number.ToString();
            string emptyString = "";
            string nullString = null;

            var variable = "";

            (int, int) w = (4, 6);
            int sum((int first, int second) a)
            {
                return a.first + a.second;
            }

            void func1()
            {
                checked
                {
                    byte var1 = 255;
                    Console.WriteLine(++var1);
                }
            }

            void func2()
            {
                unchecked
                {
                    byte var1 = 255;
                    Console.WriteLine(++var1);
                }
            }

            Console.WriteLine("My name is {0}", String.Format(name));
            Console.WriteLine($"My name is {name}");

            Console.WriteLine($"number.GetType() = {number.GetType()}, name.GetType() = {name.GetType()}");
            Console.WriteLine($"number.Equals(name) = {number.Equals(name)}");
            Console.WriteLine($"name.Equals(str) = {name.Equals(str)}");
            Console.WriteLine($"numToString.GetType() = {numToString.GetType()}");

            Console.WriteLine($"String.Compare(name, str) = {String.Compare(name, str)}");
            Console.WriteLine($"name.Contains(str) = {name.Contains(str)}");
            Console.WriteLine($"name.Substring(2, 4) = {name.Substring(2, 4)}");
            Console.WriteLine($"name.Insert(1, str) = {name.Insert(1, str)}");
            Console.WriteLine($"name.Insert(1, str) = {name.Replace("t", "w")}");

            Console.WriteLine($"emptyString.IsNullOrEmpty(emptyString) = {String.IsNullOrEmpty(emptyString)}");
            Console.WriteLine($"nullString.IsNullOrEmpty(nullString) = {String.IsNullOrEmpty(nullString)}");

            Console.WriteLine($"y = {y}");
            Console.WriteLine($"sum(w) = {sum(w)}");

            
            func2();

            Console.ReadKey();
        }
    }
}
