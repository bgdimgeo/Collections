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

            string message = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                string[] inputArgs = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputArgs[0];
                if (command == "InsertSpace")
                {
                    int spaceIndex = int.Parse(inputArgs[1]);
                    message = message.Insert(spaceIndex," ");
                }
                else if (command == "Reverse")
                {
                    string substringValue = inputArgs[1];
                    if (message.Contains(substringValue))
                    {
                        int index = message.IndexOf(substringValue);
                        int length = substringValue.Length;
                        message = message.Remove(index, length);
                        char[] charArray = substringValue.ToCharArray();
                        Array.Reverse(charArray);
                        string newSubstring = new string(charArray);
                        message = message.Insert(index, newSubstring);
                    }

                }
                else if (command == "ChangeAll") 
                {
                    string substringValue = inputArgs[1];
                    string replacment = inputArgs[2];
                    if (message.Contains(substringValue))
                    {
                        message = message.Replace(substringValue, replacment);
                    }
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"You have a new text message: {string.Join("",message)}");
        }
    }
}