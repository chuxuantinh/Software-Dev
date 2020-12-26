using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> Players = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string line = Console.ReadLine();
                string[] linesplit = line.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (line == "Season end")
                {
                    foreach (var p in Players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Key))
                    {
                        Console.WriteLine($"{p.Key}: {p.Value.Values.Sum()} skill");
                        foreach (var pos in p.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                        {

                            Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                        }
                    }
                    return;
                }
                if (linesplit.Length == 3 && !linesplit.Contains("vs"))
                {
                    string PlayersName = linesplit[0];
                    string position = linesplit[1];
                    int skill = int.Parse(linesplit[2]);

                    if (!Players.ContainsKey(PlayersName))
                    {
                        Players.Add(PlayersName, new Dictionary<string, int>());
                        Players[PlayersName].Add(position, skill);
                    }


                    if (Players[PlayersName].ContainsKey(position))
                    {
                        if (Players[PlayersName][position] < skill)
                            Players[PlayersName][position] = skill;
                    }
                    else
                    {
                        Players[linesplit[0]].Add(linesplit[1], skill);
                    }

                }
                if (linesplit.Length == 3 && linesplit.Contains("vs"))
                {
                    string firstplayer = linesplit[0];
                    string secondplayer = linesplit[2];
                    if (Players.ContainsKey(firstplayer) && Players.ContainsKey(secondplayer))
                    {
                        string[] firstplayerpositions = Players[firstplayer].Keys.ToArray();
                        foreach (var pos2 in Players[secondplayer].Keys)
                        {
                            if (firstplayerpositions.Contains(pos2))
                            {
                                int totalSkillsfp = Players[firstplayer].Values.Sum();
                                int totalSkillssp = Players[secondplayer].Values.Sum();
                                if (totalSkillsfp > totalSkillssp)
                                {
                                    Players.Remove(secondplayer);
                                    break;
                                }
                                if (totalSkillsfp < totalSkillssp)
                                {
                                    Players.Remove(firstplayer);
                                    break;
                                }


                            }
                        }
                    }
                }

            }
        }
    }
}