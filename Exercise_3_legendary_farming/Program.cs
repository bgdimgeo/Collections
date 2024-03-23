using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Legendary_farming
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                { "shards",0},
                { "motes",0},
                { "fragments", 0}
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();
            string itemObtained = string.Empty;

            //Unlimited number of rows to be read  
            while (String.IsNullOrEmpty(itemObtained)) 
            {
                string materialsLine = Console.ReadLine().ToLower(); // program should be case insensitive
                string[] materialsArr = materialsLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                ProcessInputLine(keyMaterials, junk, materialsArr, ref itemObtained);
            }
            PrintOutput(keyMaterials, junk, itemObtained);
        }
        static void ProcessInputLine(Dictionary<string,int> keyMaterials, Dictionary<string,int> junk,
            string[] materialsArr, ref string itemObtained) 
        {
            Dictionary<string, string> cragtingTable = new Dictionary<string, string>()
            {
                { "shards","Shadowmourne"},
                {"fragments","Valanyr" },
                { "motes","Dragonwrath"}
            };
            const int minCraftMaterialQty = 250;
            
            for (int i = 0; i < materialsArr.Length; i += 2)
            {
                string currMaterial = materialsArr[i + 1];
                int currMaterialQty = int.Parse(materialsArr[i]);
                if (keyMaterials.ContainsKey(currMaterial))
                {
                    keyMaterials[currMaterial] += currMaterialQty;
                    if (keyMaterials[currMaterial] >= minCraftMaterialQty)
                    {
                        itemObtained = cragtingTable[currMaterial];
                        keyMaterials[currMaterial] -= minCraftMaterialQty;
                        break;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(currMaterial))
                    {
                        //Firstly add the new resource, we set default qty
                        junk[currMaterial] = 0;
                    }
                    junk[currMaterial] += currMaterialQty;
                }

            }

        }
        static void PrintOutput(Dictionary<string, int> keyMaterialsLeft, Dictionary<string, int> junk, string itemObtained) 
        {
            Console.WriteLine($"{itemObtained} obtained!");
            foreach (var kvp in keyMaterialsLeft) 
            {
                string keyMaterial = kvp.Key;
                int qtyLeft = kvp.Value;
                Console.WriteLine($"{keyMaterial}: {qtyLeft}");
            }
            foreach (var kvp in junk)
            {
                string junkMaterial = kvp.Key;
                int junkQty = kvp.Value;
                Console.WriteLine($"{junkMaterial}: {junkQty}");
            }
        }
    }
}