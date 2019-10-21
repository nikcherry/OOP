using System;

namespace ConsoleApp1
{
    partial class Abiturient
    {
        private readonly int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static int count;
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int[] Marks { get; set; }
        public const string University = "BSTU";

        static Abiturient()
        {
            count = 0;
        }
        public Abiturient()
        {
            count++;
            id = count;
        }
        public Abiturient(string _FirstName, string _LastName) : this()
        {
            FirstName = _FirstName;
            LastName = _LastName;
            id = FirstName.GetHashCode() + LastName.GetHashCode();
        }
        public Abiturient(string _FirstName, string _LastName, int[] _Marks) : this()
        {
            FirstName = _FirstName;
            LastName = _LastName;
            Marks = _Marks;
            id = FirstName.GetHashCode() + LastName.GetHashCode();
        }
        ~Abiturient()
        {
            count--;
        }

        public double getAvg()
        {
            double sum = 0;
            foreach(int x in Marks)
            {
                sum += x;
            }
            return (sum / Marks.Length);
        }

        public int getMin()
        {
            int min = Marks[0];
            foreach (int x in Marks)
            {
                if (x <= min)
                {
                    min = x;
                }
            }
            return min;
        }

        public int getMax()
        {
            int max = Marks[0];
            foreach (int x in Marks)
            {
                if (x >= max)
                {
                    max = x;
                }
            }
            return max;
        }

        public int getSum()
        {
            int sum = 0;
            foreach(int x in Marks)
            {
                sum += x;
            }
            return sum;
        }
    }

    partial class Abiturient
    {
        public static int getCount()
        {
            return count;
        }

        public override bool Equals(object obj)
        {
            Abiturient abitur = (Abiturient)obj;
            return ((this.FirstName == abitur.FirstName) && (this.LastName == abitur.LastName) && (this.Adress == abitur.Adress));
        }

        public override string ToString()
        {
            return (this.FirstName + " " + this.LastName);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() + this.LastName.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Abiturient[] abiturients = new Abiturient[3];
            int[][] marks = new int[3][];
            marks[0] = new int[4] { 3, 2, 4, 6 };
            marks[1] = new int[4] { 7, 8, 6, 7 };
            marks[2] = new int[4] { 9, 8, 9, 8 };
            abiturients[0] = new Abiturient();
            abiturients[1] = new Abiturient("Stepan", "Arhipov");
            abiturients[2] = new Abiturient("Vadim", "Tsibulevich", marks[2]);

            abiturients[0].FirstName = "Bad";
            abiturients[0].LastName = "Student";
            abiturients[0].Adress = "123";
            abiturients[1].Adress = "123";
            abiturients[0].Marks = marks[0];
            abiturients[1].Marks = marks[1];

            Console.WriteLine("Avg marks:");
            foreach(Abiturient x in abiturients)
            {
                Console.WriteLine($"{x.FirstName} {x.LastName} avg marks is {x.getAvg()}.");
            }
            Console.WriteLine($"\nNumber of abiturients is {Abiturient.getCount()}.");

            Console.WriteLine($"\nStudents with bad marks:");
            foreach (Abiturient x in abiturients)
            {
                if (x.getMin() < 4)
                    Console.WriteLine($"{x.FirstName} {x.LastName}");
            }
            Console.WriteLine();
            foreach (Abiturient x in abiturients)
            {
                if (x.getSum() > 20)
                {
                    Console.WriteLine($"{x.FirstName} {x.LastName}");
                }
            }
            Console.WriteLine($"\nabiturients[0].Equals(abiturients[1]) = {abiturients[0].Equals(abiturients[1])}");
            Console.WriteLine($"abiturients[1].ToString() = {abiturients[1].ToString()}");
        }
    }
}
