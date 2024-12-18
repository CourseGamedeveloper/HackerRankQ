//Q1
//link for the Q4: https://www.hackerrank.com/challenges/non-divisible-subset/problem?isFullScreen=true
//sol
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
         int[] remainderCounts = new int[k];

        // Count remainders
        foreach (int num in s)
        {
            int remainder = num % k;
            remainderCounts[remainder]++;
        }

        // Start with at most one element with remainder 0
        int maxSubsetSize = Math.Min(remainderCounts[0], 1);

        // Iterate through possible remainders
        for (int i = 1; i <= k / 2; i++)
        {
            if (i == k - i) // Special case: remainder is exactly k/2
            {
                maxSubsetSize += Math.Min(remainderCounts[i], 1);
            }
            else
            {
                maxSubsetSize += Math.Max(remainderCounts[i], remainderCounts[k - i]);
            }
        }

        return maxSubsetSize;
    }

    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

