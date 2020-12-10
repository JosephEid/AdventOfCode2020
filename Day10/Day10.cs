using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Day10
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
                    // Part2();
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
                vals.Add(Int32.Parse(line));
            }
            int diff1 = 1;
            int diff2 = 0;
            int diff3 = 1;
            vals.Sort();
            for (int i = 0; i < vals.Count - 1; i++)
            {
                int diff = vals[i+1] - vals[i];
                switch (diff)
                {
                    case 1: diff1 ++;
                            break;
                    case 2: diff2 ++;
                            break;
                    case 3: diff3 ++;
                            break;
                }
            }
            Console.WriteLine(diff1 * diff3);
        }
    }
}
