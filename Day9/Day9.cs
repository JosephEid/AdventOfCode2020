using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Day9
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "1")
                {
                    Part1();
                } 
                else if (args[0] == "2")
                {
                    Part2();
                } 
                else 
                {
                    Console.WriteLine($"Please specify which part of the exercise you would like to run e.g dotnet run {"'1'"}");
                }
            } 
            else {
                Console.WriteLine($"Please specify which part of the exercise you would like to run e.g dotnet run {"'1'"}");
            }
        }

        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<int> vals = new List<int>();

            foreach (string line in input)
            {
                vals.Add((int)Int64.Parse(line));
            }
            for (int i = 25; i < vals.Count; i++)
            {
                List<int> prev25 = vals.GetRange(i-25, 25);
                bool found = false;
                for (int j = 0; j < prev25.Count; j++)
                {
                    for (int k = 0; k < prev25.Count; k++)
                    {
                        if (j != k) if (prev25[j] + prev25[k] == vals[i]) found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine(vals[i]);
                    goto End;
                }
            }
            End: Console.WriteLine("End found");
        }

        static void Part2()
        {
            long num = 22406676;
            string[] input = File.ReadAllLines("input.txt");
            List<long> vals = new List<long>();

            foreach (string line in input)
            {
                vals.Add(Int64.Parse(line));
            }
            // Subset problem: Start with subsets of two and 
            // increase until we get to length of input.
            for (int i = 2; i < vals.Count; i++)
            {
                for (int j = 0; j <= vals.Count - i; j++)
                {
                    List<long> subset = vals.GetRange(j, i);
                    long result = subset.Sum();
                    if (result == num) 
                    {
                        Console.WriteLine(subset.Max() + subset.Min());
                    }
                }
            }
        }
    }
}
