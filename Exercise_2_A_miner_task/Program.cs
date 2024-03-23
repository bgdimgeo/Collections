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
              Dictionary<string,long> resources= new Dictionary<string,long>();
            string resourceCmd = " ";
            while ((resourceCmd = Console.ReadLine()) != "stop")
            {
                int qty = int.Parse(Console.ReadLine());
                //if (resources.ContainsKey(resourceCmd))
                //{
                //    // The given resource exist
                //    resources[resourceCmd] += qty;
                //}
                //else 
                //{
                //    resources.Add(resourceCmd, qty);
                //}
                //Add new qty to existing one 
                if (!resources.ContainsKey(resourceCmd)) 
                {
                    //Firstly add the new resource, we set default qty
                    resources[resourceCmd] = 0;
                }
                resources[resourceCmd] += qty;
            
            }
            foreach (var rqp in resources) 
            {
                string currResource = rqp.Key;
                long resourceQty = rqp.Value;
                Console.WriteLine($"{currResource} -> {resourceQty}");
            }
        }
    }
}