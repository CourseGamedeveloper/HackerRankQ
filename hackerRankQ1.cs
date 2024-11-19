//Q1
//link for the Q1 https://www.hackerrank.com/challenges/magic-square-forming/problem?isFullScreen=true
//sol:
using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    /*
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */
    public static int formingMagicSquare(List<List<int>> s)
    {
        // All 8 possible 3x3 magic squares
        int[][][] magicSquares = new int[][][]
        {
            new int[][] { new int[] { 8, 1, 6 }, new int[] { 3, 5, 7 }, new int[] { 4, 9, 2 } },
            new int[][] { new int[] { 6, 1, 8 }, new int[] { 7, 5, 3 }, new int[] { 2, 9, 4 } },
            new int[][] { new int[] { 4, 9, 2 }, new int[] { 3, 5, 7 }, new int[] { 8, 1, 6 } },
            new int[][] { new int[] { 2, 9, 4 }, new int[] { 7, 5, 3 }, new int[] { 6, 1, 8 } },
            new int[][] { new int[] { 8, 3, 4 }, new int[] { 1, 5, 9 }, new int[] { 6, 7, 2 } },
            new int[][] { new int[] { 4, 3, 8 }, new int[] { 9, 5, 1 }, new int[] { 2, 7, 6 } },
            new int[][] { new int[] { 6, 7, 2 }, new int[] { 1, 5, 9 }, new int[] { 8, 3, 4 } },
            new int[][] { new int[] { 2, 7, 6 }, new int[] { 9, 5, 1 }, new int[] { 4, 3, 8 } }
        };

        int minCost = int.MaxValue;

        // Compare input square with each magic square
        foreach (var magicSquare in magicSquares)
        {
            int cost = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cost += Math.Abs(s[i][j] - magicSquare[i][j]);
                }
            }

            minCost = Math.Min(minCost, cost);
        }

        return minCost;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read input
        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(int.Parse).ToList());
        }

        // Calculate minimal cost
        int result = Result.formingMagicSquare(s);

        // Output the result
        Console.WriteLine(result);
    }
}
