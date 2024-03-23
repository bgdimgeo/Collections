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
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> occurences = new Dictionary<string, int>();
            foreach (string word in words) 
            {
                string lowerCaseWord = word.ToLower();
                if (occurences.ContainsKey(lowerCaseWord))
                {
                    occurences[lowerCaseWord] += 1;
                }
                else 
                {
                    occurences.Add(lowerCaseWord, 1);
                }
            }

            string[] result = occurences.Where(item => item.Value % 2 != 0).Select(item => item.Key).ToArray();
            Console.WriteLine(string.Join(" ", result));
            //foreach (var item in occurences) 
            //{
            //    if (item.Value % 2 != 0)
            //    {
            //        Console.Write($"{item.Key} ");
            //    }
                
            //}
            //Console.WriteLine();
        }
    }
}