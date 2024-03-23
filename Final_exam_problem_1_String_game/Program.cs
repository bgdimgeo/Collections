using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringGame
{
    internal class StringGame
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Done") 
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputArgs[0];
                if (command == "Change")
                {
                    char oldChar = char.Parse(inputArgs[1]);
                    char newChar = char.Parse(inputArgs[2]);

                    word = word.Replace(oldChar, newChar);

                    Console.WriteLine(word);
                }
                else if (command == "Includes")
                {
                    if (word.Contains(inputArgs[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "End")
                {
                    string subString = inputArgs[1];
                    if (word.EndsWith(subString) == true)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Uppercase")
                {
                    word = word.ToUpper();
                    Console.WriteLine(word);
                }
                else if (command == "FindIndex")
                {
                    char currChar = char.Parse(inputArgs[1]);
                    int index = word.IndexOf(currChar);
                    Console.WriteLine(index);
                }
                else if (command == "Cut") 
                {
                    int index = int.Parse(inputArgs[1]);
                    int length = int.Parse(inputArgs[2]);
                    string newWord = word.Substring(index, length);
                    word = newWord;
                    Console.WriteLine(word);
                }
                input = Console.ReadLine();

            }

        }
    }
}