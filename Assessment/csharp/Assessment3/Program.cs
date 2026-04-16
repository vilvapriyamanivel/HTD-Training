using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{

    class CricketTeam
    {
        public (int MatchCount, int Sum, double Average) Pointscalculation(int no_of_matches)
        {
            int sum = 0;

            Console.WriteLine("Enter the points scored in each match:");

            for (int i = 1; i <= no_of_matches; i++)
            {
                Console.Write("Match " + i + ": ");
                int score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }

            double average = (double)sum / no_of_matches;

            return (no_of_matches, sum, average);
        }
    }

    class Program
    {
        static void Main()
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter number of matches played: ");
            int no_of_matches = Convert.ToInt32(Console.ReadLine());

            var result = team.Pointscalculation(no_of_matches);

            Console.WriteLine("\n--- IPL Team Points Summary ---");
            Console.WriteLine("Total Matches : " + result.MatchCount);
            Console.WriteLine("Total Points  : " + result.Sum);
            Console.WriteLine("Average Points: " + result.Average);
        }
    }
}
