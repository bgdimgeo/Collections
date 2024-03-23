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
            int pairCount = int.Parse(Console.ReadLine());
            // test [exam, evaluation]
            // cute - [addorable, charming]

            Dictionary<string, List<string>> synonimList = new Dictionary<string, List<string>>();

            for (int i = 0; i < pairCount; i++) 
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (synonimList.ContainsKey(word))
                {
                    synonimList[word].Add(synonym);
                }
                else 
                {
                    List<string> newSymList = new List<string>();
                    newSymList.Add(synonym);
                    synonimList.Add(word, newSymList);
                }
            }
            foreach (var item in synonimList) 
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
            }
        }
    }
}