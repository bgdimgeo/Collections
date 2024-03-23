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
            int a = 10;
            int b = 20;
            int c = a > b ? a : b;
            Console.WriteLine(c);
            bool isTrue1 = 5 > 'a';
            bool isTrue2 = "string" == "String";
            bool isTrue3 = 100f == 100d;
            bool isTrue4 = 100f != 100d;

            Console.WriteLine(isTrue1);
            Console.WriteLine(isTrue2);
            Console.WriteLine(isTrue3);
            Console.WriteLine(isTrue4);

            int j = ++a;
            Console.WriteLine(j);
            string name = "George";

            Console.WriteLine(name[2]);
        }
    }
}