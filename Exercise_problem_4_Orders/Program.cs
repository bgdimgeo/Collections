using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Orders
{
    class SoftUniStudents
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> materialList = new Dictionary<string, List<double>>();
            string command = Console.ReadLine();
            while (command != "buy") 
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string product = input[0];
                double price = double.Parse(input[1]);
                double qty = double.Parse(input[2]);
                if (!materialList.ContainsKey(product))
                {
                    materialList[product] = new List<double>();
                    materialList[product].Add(price);
                    materialList[product].Add(qty);
                }
                else
                {
                    materialList[product][0] = price;
                    materialList[product][1] += qty;
                }

                command = Console.ReadLine();
            }

            foreach (var kvp in materialList)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value[0]*kvp.Value[1]:f2}");
            }
        }
    }
}
