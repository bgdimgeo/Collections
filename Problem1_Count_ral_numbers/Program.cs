using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numebrs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            //Dictionary where we have the number and the value is how many time w saw it 
            SortedDictionary<int, int> occurences = new SortedDictionary<int, int>();

            foreach (int n in numebrs) 
            {
                if (occurences.ContainsKey(n))
                {
                    occurences[n] += 1;
                }
                else 
                {
                    occurences.Add(n, 1);
                }
            }
            foreach (var item in occurences) 
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}