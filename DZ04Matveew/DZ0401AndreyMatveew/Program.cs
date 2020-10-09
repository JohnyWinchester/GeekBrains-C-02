using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /*Матвеев Андрей. Задание 2.
     *Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
      для целых чисел;
    * для обобщенной коллекции;
    **используя Linq.
    */
    class Program
    {
        static void Main(string[] args)
        {
            IntegerCollection(new List<int>() {1,2,3,1,2,3});
            GenericCollection(new List<string>() { "1", "2", "3", "1", "2" });
            LinqCollection(new List<string>() { "1", "2", "3", "1", "2" });

            Console.ReadKey();
        }

        public static void IntegerCollection(List<int> list)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            foreach(int el in list)
            {
                if (pairs.ContainsKey(el)) pairs[el]++;
                else pairs.Add(el, 1);
            }
            Console.WriteLine("Решение для целых чисел:");
            foreach (var el in pairs)
                Console.WriteLine($"Значение: {el.Key} - {el.Value}");
        }

        public static void GenericCollection<T> (List<T> list)
        {
            Dictionary<T, int> pairs = new Dictionary<T, int>();
            foreach (T el in list)
            {
                if (pairs.ContainsKey(el)) pairs[el]++;
                else pairs.Add(el, 1);
            }
            Console.WriteLine("\nРешение для обобщенной коллекции:");
            foreach (var el in pairs)
                Console.WriteLine($"Значение: {el.Key} - {el.Value}");

        }

        public static void LinqCollection<T>(List<T> list)
        {
            var pairs = list.GroupBy(e => e).
                              Select(g => new { Name = g.Key, Count = g.Count() });
            Console.WriteLine("\nРешение используя Linq:");
            foreach (var el in pairs)
                Console.WriteLine($"Значение: {el.Name} - {el.Count}");
        }
    }
}
