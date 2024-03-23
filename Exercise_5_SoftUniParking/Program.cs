using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) 
            {
                string[] cmdArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmdType = cmdArgs[0];
                string usrName = cmdArgs[1];
                if (cmdType == "register") 
                {
                    string licensePlateNumber = cmdArgs[2];
                    RegisterUser(parkingRegister, usrName, licensePlateNumber);

                }
                else if(cmdType == "unregister") 
                {
                    UnRegisterUser(parkingRegister, usrName);
                }
            }
            foreach (var kvp in parkingRegister) 
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }

        }

        static void RegisterUser(Dictionary<string, string> parkingRegister, string username, string licensePlateNumber) 
        {
            if (parkingRegister.ContainsKey(username))
            {
                string licenseNumberRegistered = parkingRegister[username];
                Console.WriteLine($"ERROR: already registered with plate number {licenseNumberRegistered}");
            }
            else

            {
                parkingRegister[username] = licensePlateNumber;
                Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
            }
        }
        static void UnRegisterUser(Dictionary<string, string> parkingRegister, string username) 
        {
            if (!parkingRegister.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else 
            {
                parkingRegister.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }

        }
    }
}