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

        static void Part2() {
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
                int pos1 = Int32.Parse(rangeSplit[0]);
                int pos2 = Int32.Parse(rangeSplit[1]);

                bool match1 = pos1 > 0 && pos1 <= password.Length  ? password[pos1-1] == letter : false; 
                bool match2 = pos2 > 0 && pos2 <= password.Length ? password[pos2-1] == letter : false;
                if (match1 ^ match2)
                {
                    count ++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
