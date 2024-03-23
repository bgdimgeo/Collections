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
            Dictionary<string, Student> gradebook = new Dictionary<string, Student>();

            gradebook.Add("3A", new Student()
            {
                Name = "Ivan",
            });
            gradebook.Add("5b", new Student()
            {
                Name = "Gosho",
            });
            foreach (var item in gradebook) 
            {
                Console.WriteLine($"Class: {item.Key}");
                Student currStudent = item.Value;
                item.Value.SayName();
                currStudent.SayName();
                Console.WriteLine(item.Value.Name);
            }
            Console.WriteLine(gradebook.Count);

            //SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();

            // phoneBook.Add("Teodor","+35987711"); // add is inserting 
            // phoneBook["Maria"] = "69554964"; // if use this expression with the samekey
            //                                  // different value we are going to overwrite the value
            // phoneBook["Ivan"] = "69554964";

            // Console.WriteLine(phoneBook.ContainsValue("69554964"));
            // phoneBook.Remove("Ivan");


            // foreach (var item in phoneBook) 
            // {
            //     Console.WriteLine($"Name: {item.Key}, phone: {item.Value}");
            // }

        }
    }
    class Student 
    {
        public string Name { get; set; }
        public void SayName()
        {
            Console.WriteLine($"{this.Name}");
        }
    }
}