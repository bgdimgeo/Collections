using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        { 
            Dictionary<string,List<string>> companyUsers = new Dictionary<string,List<string>>();
            string command = Console.ReadLine();
            while (command != "End") 
            {
                string[] inputArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = inputArgs[0];
                string id = inputArgs[1];
                if (!companyUsers.ContainsKey(company))
                {
                    companyUsers[company] = new List<string>();
                    companyUsers[company].Add(id);
                }
                else 
                {
                    if (!companyUsers[company].Contains(id)) 
                    {
                        companyUsers[company].Add(id);
                    }
                }

                command = Console.ReadLine();
            }
            foreach (var kvp in companyUsers) 
            {
                Console.WriteLine($"{kvp.Key}");
                for (int i = 0; i < kvp.Value.Count; i++) 
                {
                    Console.WriteLine($"-- {kvp.Value[i]}");
                }
            }
        }
    }
}