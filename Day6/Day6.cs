using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day6
{
    class Day6
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
            List<string> groups = new List<string>();

            string builder = "";

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i].Trim();
                
                if (String.IsNullOrEmpty(line))
                {
                    groups.Add(builder.TrimEnd());
                    builder = "";
                }
                else if (i == input.Length - 1)
                {
                    builder += $"{line}";
                    groups.Add(builder.TrimEnd());
                    builder = "";
                }
                else
                {
                    builder += $"{line}";
                }
            }
            int sum = 0;
            foreach (string group in groups)
            {
                sum += group.Distinct().Count();
                // List<string> persons = group.Split(" ").ToList();
                // persons.ForEach(x => Console.WriteLine($"person: {x}"));
            }
            Console.WriteLine(sum);
        }
    }
}
