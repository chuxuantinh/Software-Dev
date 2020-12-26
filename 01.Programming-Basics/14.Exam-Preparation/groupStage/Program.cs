using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());
            int points = 0;
            int totalGoalsScored = 0;
            int totalGoalsReceived = 0;
            for (int i = 0; i < gamesPlayed; i++)
            {
                int goalsScored = int.Parse(Console.ReadLine());
                int goalsReceived = int.Parse(Console.ReadLine());
                if (goalsScored > goalsReceived)
                {
                    points += 3;
                }
                else if (goalsScored == goalsReceived)
                {
                    points += 1;
                }
                totalGoalsScored += goalsScored;
                totalGoalsReceived += goalsReceived;
            }
            int goalDifference = totalGoalsScored - totalGoalsReceived;
            if (totalGoalsScored >= totalGoalsReceived)
            {
                Console.WriteLine($"{teamName} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {goalDifference}.");
            }
            else
            {
                Console.WriteLine($"{teamName} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {goalDifference}.");
            }
        }
    }
}
