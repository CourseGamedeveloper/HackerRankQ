//Q1
//link for the Q2: https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem?isFullScreen=true
//sol:
using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    /*
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        // Remove duplicates and sort the leaderboard in descending order
        List<int> uniqueRanked = ranked.Distinct().ToList();
        uniqueRanked.Sort((a, b) => b.CompareTo(a));

        List<int> result = new List<int>();
        int rankIndex = uniqueRanked.Count - 1; // Start from the lowest rank

        foreach (int score in player)
        {
            // Move up the leaderboard for scores greater than the player's
            while (rankIndex >= 0 && score >= uniqueRanked[rankIndex])
            {
                rankIndex--;
            }
            // Player's rank is the next one after rankIndex
            result.Add(rankIndex + 2);
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read ranked leaderboard scores
        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(int.Parse).ToList();

        // Read player's scores
        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(int.Parse).ToList();

        // Calculate the player's rankings after each game
        List<int> result = Result.climbingLeaderboard(ranked, player);

        // Output the result
        foreach (int rank in result)
        {
            Console.WriteLine(rank);
        }
    }
}

