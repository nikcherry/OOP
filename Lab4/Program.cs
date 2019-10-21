using System;

namespace ConsoleApp1
{
    public static class StaticOperation
    {
        public static int fingAvg(this Set set)
        {
            int sum = 0;
            for (int i = 0; i < set.count; i++)
            {
                sum += set.set[i];
            }
            return sum;
        }

        public static int count(this Set set)
        {
            return set.count;
        }

        public static int MinMax(this Set set)
        {
            int min = set.set[0];
            int max = set.set[0];

            for (int i = 0; i < set.count; i++)
            {
                if (set.set[i] <= min)
                    min = set.set[i];
            }

            for (int i = 0; i < set.count; i++)
            {
                if (set.set[i] >= max)
                    max = set.set[i];
            }

            return max - min;
        }
        public static int Min(this Set set)
        {
            int min = set.set[0];
            for (int i = 0; i < set.count; i++)
            {
                if(set.set[i] <= min)
                {
                    min = set.set[i];
                }
            }
            return min;
        }
    }

    public class Owner
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }

        public Owner()
        {
            id = 0;
        }

        public Owner(int _id, string _Name, string _Organization)
        {
            id = _id;
            Name = _Name;
            Organization = _Organization;
        }
    }

    public class Set
    {
        public int Size;
        public Owner owner;
        public int[] set;
        public int count = 0;
        public DateTime date;

        public Set()
        {
            Size = 100;
            set = new int[Size];
            owner = new Owner();
            date = DateTime.Now;
        }
        public Set(int _size)
        {
            Size = _size;
            set = new int[_size];
            owner = new Owner();
            date = DateTime.Now;
        }
        public Set(int _size, int _id, string _Name, string _Organization)
        {
            Size = _size;
            set = new int[_size];
            owner = new Owner(_id, _Name, _Organization);
            date = DateTime.Now;
        }

        public bool isFull()
        {
            return (count == Size);
        }

        public void add(int elem)
        {
            if (isFull())
            {
                Console.WriteLine("Full");
            }
            for (int i = 0; i < count; i++)
            {
                if (set[i] == elem)
                {
                    return;
                }
            }
            set[count++] = elem;
        }

        public void show()
        {
            Console.WriteLine("Elements:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(set[i]);
            }
        }
        public static Set operator >>(Set _set, int num)
        {
            for (int i = 0; i < _set.count; i++)
            {
                if (_set.set[i] == num)
                {
                    for (int j = i; j < _set.count - 1; j++)
                    {
                        _set.set[j] = _set.set[j + 1];
                    }
                    _set.count--;
                    return _set;
                }
            }
            return _set;
        }

        public static Set operator <<(Set _set, int num)
        {
            _set.add(num);
            return _set;
        }

        public static Set operator %(Set set1, Set set2)
        {
            int newSize = 100;
            if (set1.Size >= set2.Size)
                newSize = set1.Size;
            else
                newSize = set2.Size;
            Set newSet = new Set(newSize);
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set2.set[j] == set1.set[i])
                    {
                        newSet.add(set2.set[j]);
                        break;
                    }
                }
            }
            return newSet;
        }

        public static bool operator <(Set set1, Set set2)
        {
            int c = 0;
            for (int i = 0; i < set2.count; i++)
            {
                for (int j = 0; j < set1.count; j++)
                {
                    if (set1.set[j] == set2.set[i])
                    {
                        c++;
                        break;
                    }
                }
            }
            return (c == set2.count);
        }

        public static bool operator > (Set set1, Set set2)
        {
            int c = 0;
            for (int i = 0; i < set2.count; i++)
            {
                for (int j = 0; j < set1.count; j++)
                {
                    if (set1.set[j] == set2.set[i])
                    {
                        c++;
                        break;
                    }
                }
            }
            return (c != set2.count);
        }

        public static bool operator ==(Set set1, Set set2)
        {
            int c = 0;
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set1.set[i] == set2.set[j])
                    {
                        c++;
                        break;
                    }
                }
            }
            return ((c == set1.count) && (c == set2.count));
        }

        public static bool operator !=(Set set1, Set set2)
        {
            int c = 0;
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set1.set[i] == set2.set[j])
                    {
                        c++;
                        break;
                    }
                }
            }
            return ((c != set1.count) && (c != set2.count));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Set s1 = new Set(5);
            Set s2 = new Set(5);
            Set s3;
            Set s4 = new Set(5);

            Console.WriteLine($"Дата создания s1: {s1.date}");

            s1.add(345);
            s1.add(123);
            s1.add(123);

            s2.add(123);
            s2.add(456);

            s4.add(123);

            Console.Write("s1 ");
            s1.show();
            Console.Write("s2 ");
            s2.show();

            s3 = s1 % s2;
            Console.Write("s3 ");
            s3.show();

            s1 = s1 >> 123;
            Console.Write("s1 ");
            s1.show();
            s1 = s1 << 789;
            Console.Write("s1 ");
            s1.show();

            Console.WriteLine($"s1 == s2: {s1 == s2}");
            Console.WriteLine($"s1 == s1: {s1 == s1}");
            Console.WriteLine($"s1 != s2: {s1 != s2}");
            Console.WriteLine($"s1 > s4: {s1 > s4}");
        }
    }
}
