using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day13
{
    class Day13
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
            List<string> input = File.ReadAllLines("input.txt").ToList();
            int timestamp = Int32.Parse(input[0]);
            List<int> busIds = input[1].Split(",").Where(x => x != "x").Select(x => Int32.Parse(x)).ToList();
            double min = Double.PositiveInfinity;
            busIds.ForEach(delegate(int id)
            {
                bool exceeded = false;
                int multiple = 1;
                while (!exceeded)
                {
                    if (id * multiple > timestamp)
                    {
                        int timeDiff = id*multiple - timestamp;
                        Console.WriteLine($"{id}: multiple: {multiple}, timeDiff: {timeDiff}, id*timeDiff = {id*timeDiff}");
                        exceeded = true;
                    }
                    multiple ++;
                }
            });
        }
    }
}
