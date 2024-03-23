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
            Dictionary<string,int> dict = new Dictionary<string, int>();
            if (!dict.ContainsKey("Pesho")) 
            {
                //dict.Add("Pesho", 5);
                dict["Pesho"] = 5;
            }
            dict["Pesho"] += 3;
            //if (dict.ContainsValue(8)) // Rare case
            //{

            //}
            List<string> keys = dict.Keys.ToList();
            //            List<int> values = dict.Values.ToList();

            foreach (string key in keys) 
            {
                Console.WriteLine($"{key} -> {dict[key]}");
            }
            //Second method 
            foreach (var kvp in dict) 
            {
                Console.WriteLine($"{kvp.Key}");
            }

            SortedDictionary<string, int> sortedStudents = new SortedDictionary<string, int>();
        }
    }
}