using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Day2
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

        static void Part1() {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;

            for (int x = 0; x < input.Length; x++)
            {
                string[] inputSplit = input[x].Split(":");
                string policy = inputSplit[0];
                string password = inputSplit[1].Trim();
                string[] policySplit = policy.Split(" ");
                string range = policySplit[0];
                char letter = Convert.ToChar(policySplit[1]);
                string[] rangeSplit = range.Split("-");
                int low = Int32.Parse(rangeSplit[0]);
                int hi = Int32.Parse(rangeSplit[1]);

                int n  = password.Count(x => x == letter);
                
                if (n >= low && n <= hi)
                {
                    count ++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
