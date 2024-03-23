using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PasswordReset
{
    internal class PasswordReset
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Done") 
            {
                if (command == "TakeOdd")
                {
                    string newPassword = String.Empty;
                    for (int i = 1; i < password.Length; i = i + 2)
                    {
                        char currChar = (char)password[i];
                        newPassword += currChar;

                    }
                    password = newPassword.ToString();
                    Console.WriteLine(password);
                }
                else if (command.Contains("Cut"))
                {
                    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int index = int.Parse(commandArgs[1]);
                    int length = int.Parse(commandArgs[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (command.Contains("Substitute")) 
                {
                    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string substring1 = commandArgs[1];
                    string substring2 = commandArgs[2];
                    if (password.Contains(substring1)) 
                    {
                        password = password.Replace(substring1, substring2);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    
                    
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}