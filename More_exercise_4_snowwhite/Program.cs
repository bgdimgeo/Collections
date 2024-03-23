using System;
using System.Collections.Generic;
using System.Linq;

class SnowWhite
{
    static void Main(string[] args)
    {
        //Dictionary<Dictionary<string, string>, int> dwarfes = new Dictionary<Dictionary<string, string>, int>();
        Dictionary<string, int> dwarfes = new Dictionary< string, int>();
        string input = Console.ReadLine();
        while (input != "Once upon a time") 
        {
            string[] parameters = input.Split(new char[] {' ', '<', ':', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = parameters[0];
            string colour = parameters[1];
            string joined = string.Join(":", name, colour);
            int score = int.Parse(parameters[2]);
            //Dictionary<string, string> currKey = new Dictionary<string, string>();
            //currKey.Add(name, colour);

            //if (!dwarfes.Any(x => x.Key.Any(x => x.Key == name && x.Value == colour )))
            if(!dwarfes.Any(x => x.Key == joined))
            {
                //dwarfes.Add(currKey, score);
                dwarfes.Add(joined, score);
            }
            else 
            {
                if(dwarfes[joined] < score)
                //if (dwarfes.First(x => x.Key.Any(x => x.Key== joined)).Value < score)
                {
                    dwarfes[joined] = score;

                    //foreach (var dwarf in dwarfes.Where(x => x.Key.Any(x => x.Key == name && x.Value == colour)))
                    //{
                    //    dwarfes.Remove(dwarf.Key);
                    //}
                    //dwarfes.Add(currKey, score);
                }
            }
            input = Console.ReadLine();
        }
        foreach (var dwarf in dwarfes.OrderByDescending(x => x.Value).
            ThenByDescending(x => dwarfes.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            //ThenByDescending(x => dwarfs.Where(y => y.Key.whe == x.Key.Split(':')[1])
            //                                 .Count()))

            //(y => y.Key.Split("-")[1] == x.Key.Split("-")[1])
        {
            //.ThenBy(x => x.Key.OrderBy(x => x.Value.Count()))
            //foreach (var pair in dwarf.Key.OrderBy(x => x.Value))
            //{
            //    //dict.Values
            //    //.SelectMany(list => list)
            //    //.Distinct()
            //    //.Count();
            //    Console.WriteLine($"({pair.Value}) {pair.Key} <-> {dwarf.Value}");
            //}
            Console.WriteLine("({0}) {1} <-> {2}",
                    dwarf.Key.Split(':')[1],
                    dwarf.Key.Split(':')[0],
                    dwarf.Value);
        }
        
    }
}