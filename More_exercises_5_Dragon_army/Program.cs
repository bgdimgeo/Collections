using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DragonArmy
{
    internal class DragonArmy
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dragonNames = new Dictionary<string, string>();
            List<Dragon> dragons = new List<Dragon>();
            List<string> dragonTypes = new List<string>();
            string filterType = String.Empty;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currType = inputArgs[0];
                string currName = inputArgs[1];
                bool exist = false;
                if (!dragonNames.ContainsKey(currName))
                {
                    dragonNames[currName] = currType;
                }
                else 
                {
                    if (currType == dragonNames[currName])
                    {
                        exist = true;
                        foreach (var dragon in dragons.Where(x => x.Name == currName)) 
                        {
                            dragon.SetDamage(inputArgs[2]);

                            dragon.SetHealth(inputArgs[3]);

                            dragon.SetArmor(inputArgs[4]);
                        }

                    }
                    else 
                    {
                        continue;
                    }
                }
                if (exist == false)
                {


                    Dragon currDragon = new Dragon(currName, currType);

                        currDragon.SetDamage(inputArgs[2]);

                        currDragon.SetHealth(inputArgs[3]);

                        currDragon.SetArmor(inputArgs[4]);

                    dragons.Add(currDragon);

                    if (!dragonTypes.Contains(currType))
                    {
                        dragonTypes.Add(currType);
                    }
                }

            }

            //dragonNames.OrderByDescending(x => x.Key);
            foreach (var type in dragonTypes)
            {
                decimal totalDamage = 0m;
                decimal totalHealth = 0m;
                decimal totalArmor = 0m;
                int count = 0;
                foreach (var name in dragonNames.Where(x => x.Value == type).OrderBy(x => x.Key))
                {

                    foreach (var dragon in dragons.Where(X => X.Name == name.Key))
                    {
                        totalDamage += dragon.Damage;
                        totalArmor += dragon.Armor;
                        totalHealth += dragon.Health;
                        count++;
                    }
                }
                Console.WriteLine($"{type}::({totalDamage/count:f2}/{totalHealth/count:f2}/{totalArmor/count:f2})");

                foreach (var name in dragonNames.Where(x => x.Value == type).OrderBy(x => x.Key))
                {

                    foreach (var dragon in dragons.Where(X => X.Name == name.Key))
                    {
                        Console.WriteLine($"-{name.Key} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                    }
                }
            }
        }
    }
        public class Dragon
        {
            public Dragon(string name, string type)
            {
                this.Name = name;
                this.Type = type;
            }
            public string Name { get; set; }
            public string Type { get; set; }
            public int Damage { get; set; }
            public int Health { get; set; }
            public int Armor { get; set; }

            public void SetDamage(string damage)
            {
                 if (damage == "null")
                 {
                     this.Damage = 45;
                 }
                 else 
                 {
                     this.Damage = int.Parse(damage);
                 }
                     
                 }
            public void SetHealth(string health)
            {
                     if (health == "null")
                     {
                         this.Health = 250;
                     }
                     else
                     {
                         this.Health = int.Parse(health);
                     }
            }
            public void SetArmor(string armor)
            {
                 if (armor == "null")
                 {
                     this.Armor = 10;
                 }
                 else
                 {
                     this.Armor = int.Parse(armor);
                 }
            }
        }
    }
