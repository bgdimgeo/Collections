using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Followers
{
   internal class Followers
    {
        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            string input = Console.ReadLine();
            while (input != "Log out") 
            {
                string[] commandArgs = input.Split(": ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commandArgs[0];
                if (command == "New follower")
                {
                    string name = commandArgs[1];
                    if (!users.Any(x => x.Name == name))
                    {
                        users.Add(new Users(name));
                    }
                }
                else if (command == "Like")
                {
                    string name = commandArgs[1];
                    int likes = int.Parse(commandArgs[2]);
                    if (!users.Any(x => x.Name == name))
                    {
                        users.Add(new Users(name, likes));
                    }
                    else
                    {
                        foreach (var user in users.Where(X => X.Name == name))
                        {
                            user.IncreaseLikes(likes);
                        }
                    }

                }
                else if (command == "Comment")
                {
                    string name = commandArgs[1];
                    if (!users.Any(x => x.Name == name))
                    {
                        Users currUser = new Users(name);
                        currUser.IncreaseComments(1);
                        users.Add(currUser);
                    }
                    else
                    {
                        foreach (var user in users.Where(X => X.Name == name))
                        {
                            user.IncreaseComments(1);
                        }
                    }

                }
                else if (command == "Blocked") 
                {
                    string name = commandArgs[1];
                    if (users.Any(x => x.Name == name))
                    {
                        users.RemoveAll(x => x.Name == name);
                    }
                    else 
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{users.Count} followers");
            foreach (var user in users) 
            {
                Console.WriteLine($"{user.Name}: {user.Likes+user.Comments}");
            }
        }
    }

    public class Users 
    {
        public Users(string name)
        {
            this.Name = name;
        }
        public Users(string name, int likes)
        {
            this.Name = name;
            this.Likes = likes;
        }

        public string Name { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

        public void IncreaseLikes(int likes) 
        {
            this.Likes += likes;
        }
        public void IncreaseComments(int comments)
        {
            this.Comments += comments;
        }

    }
}