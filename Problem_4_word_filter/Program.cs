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
            string[] result = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).
                Where(word => word.Length % 2 == 0).ToArray();
            foreach (var item in result) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
