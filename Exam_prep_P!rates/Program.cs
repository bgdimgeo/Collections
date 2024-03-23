using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Pirates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            string command = Console.ReadLine();
            while (command != "Sail")
            {
                string[] input = command.Split("||",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (!towns.Any(x => x.Name == name))
                {
                    Town currTown = new Town(name, population, gold);
                    towns.Add(currTown);
                }
                else 
                {
                    foreach (var town in towns.Where(x => x.Name == name)) 
                    {
                        town.AddGold(gold);
                        town.AddPopulation(population);
                    }
                }
                command = Console.ReadLine();

            }
            command = Console.ReadLine();
            while (command != "End")
            {
                string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = input[0];
                if (action == "Plunder")
                {
                    bool delete = false;
                    foreach (var town in towns.Where(x => x.Name == input[1]))
                    {
                        delete = town.Plunder(int.Parse(input[3]), int.Parse(input[2]));
                    }
                    if (delete == true) 
                    {
                        towns.RemoveAll(x => x.Name == input[1]);
                    }
                }
                else if (action == "Prosper")
                {
                    foreach (var town in towns.Where(x => x.Name == input[1]))
                    {
                        town.Prosper(int.Parse(input[2]));
                    }

                }
                command = Console.ReadLine();
            }
            if (towns.Count != 0) 
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var town in towns) 
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
        }
    }
    public class Town 
    {
        public Town(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public void AddGold(int gold) 
        {
            this.Gold += gold;
        }
        public void AddPopulation(int population)
        {
            this.Population += population;
        }
        public bool Plunder(int gold, int people) 
        {
            bool destroyed = false;
            if (this.Gold - gold <= 0 || this.Population - people <= 0)
            {
                Console.WriteLine($"{this.Name} plundered! {gold} gold stolen, {people} citizens killed.");
                Console.WriteLine($"{this.Name} has been wiped off the map!");
                return destroyed = true;
            }
            else 
            {
                Console.WriteLine($"{this.Name} plundered! {gold} gold stolen, {people} citizens killed.");
                this.Gold -= gold;
                this.Population -= people;
                return destroyed = false;
            }
        }
        public void Prosper(int gold)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else 
            {
                Console.WriteLine($"{gold} gold added to the city treasury. {this.Name} now has {this.Gold+gold} gold.");
                this.Gold += gold;
            }
        }
    }
}