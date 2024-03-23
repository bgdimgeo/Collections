using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MOBA
{
    internal class Judge
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> skills = new Dictionary<string, List<string>>();
            List<Player> players = new List<Player>();
            while (input != "Season end")
            {
                string[] keyValues = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (keyValues.Length > 1)
                {
                    string player = keyValues[0];
                    string skill = keyValues[1];
                    int score = int.Parse(keyValues[2]);
                    if (!skills.ContainsKey(skill))
                    {
                        skills[skill] = new List<string>();
                        skills[skill].Add(player);
                        if (!players.Any(x => x.Name == player))
                        {
                            Player currPlayer = new Player(player);
                            currPlayer.ScorePerSkill.Add(skill, score);
                            players.Add(currPlayer);
                        }
                        else
                        {
                            players.First(x => x.Name == player).ScorePerSkill.Add(skill, score);
                        }
                    }
                    else
                    {
                        if (!skills[skill].Contains(player))
                        {
                            skills[skill].Add(player);
                            if (!players.Any(x => x.Name == player))
                            {
                                Player currPlayer = new Player(player);
                                currPlayer.ScorePerSkill.Add(skill, score);
                                players.Add(currPlayer);
                            }
                            else
                            {
                                players.First(x => x.Name == player).ScorePerSkill.Add(skill, score);
                            }
                        }
                        else
                        {
                            if (players.First(x => x.Name == player).ScorePerSkill[skill] < score)
                            {
                                players.First(x => x.Name == player).ScorePerSkill[skill] = score;
                            }
                        }
                    }
                }
                else 
                {
                    string[] contest = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string player1 = contest[0];
                    string player2 = contest[1];
                    string playerToRemove = Fight(players, player1, player2);
                    if (playerToRemove != string.Empty)
                    {
                        players.RemoveAll(x => x.Name == playerToRemove);

                    }
                }

                input = Console.ReadLine();
            }
            PrintPlayers(players);

        }

        public static string Fight(List<Player> players, string player1, string player2) 
        {
            string name = string.Empty;

            if (players.Any(x => x.Name == player1) && players.Any(x => x.Name == player1)) 
            {
                Dictionary<string, int> player1Skills = new Dictionary<string, int>();
                Dictionary<string, int> player2Skills = new Dictionary<string, int>();
                foreach (var player in players.Where(x => x.Name == player1)) 
                {
                    foreach (var (skill, score) in player.ScorePerSkill) 
                    {
                        player1Skills[skill] = score;
                    }
                }
                foreach (var player in players.Where(x => x.Name == player2))
                {
                    foreach (var (skill, score) in player.ScorePerSkill)
                    {
                        player2Skills[skill] = score;
                    }
                }
                foreach (var kvp in player1Skills) 
                {
                    foreach (var kvp2 in player2Skills.Where(x => x.Key == kvp.Key)) 
                    {
                        if (kvp2.Value < kvp.Value) 
                        {
                            foreach (var player in players.Where(x => x.Name == player2)) 
                            {
                               return name = player2;
                            }
                        }
                        if (kvp2.Value > kvp.Value)
                        {
                            foreach (var player in players.Where(x => x.Name == player2))
                            {
                                return name = player1;
                            }
                        }

                    }
                }
            }
            return name;

        }
        public static void PrintPlayers(List<Player> players) 
        {
            Dictionary<string, int> playersTotalScore = new Dictionary<string, int>();

            foreach (Player player in players) 
            {
                int totalSum = player.ScorePerSkill.Values.Sum();
                playersTotalScore[player.Name] = totalSum;
            }

            foreach (var player in playersTotalScore.OrderByDescending(x => x.Value).ThenBy(u => u.Key)) 
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");

                    foreach (Player kvp in players.Where(x => x.Name == player.Key)) 
                    {
                       Dictionary<string, int> skillNScore = new Dictionary<string, int>();
                       foreach (var (skill, score) in kvp.ScorePerSkill) 
                        {
                            skillNScore[skill] = score;
                        }
                    foreach (var kvp2 in skillNScore.OrderByDescending(x => x.Value).ThenBy(u => u.Key)) 
                    {
                        Console.WriteLine($"- {kvp2.Key} <::> {kvp2.Value}");
                    }


                    }
                }
            }

        }
    }
    public class Player 
    {
        public string Name { get; set; }
        public Dictionary<string, int> ScorePerSkill { get; set; }

        public Player(string name)
        {
            this.Name = name;
            ScorePerSkill = new Dictionary<string, int>();
        }


    }