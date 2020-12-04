using System;
using System.IO;

namespace Day3
{
    class Day3
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
            int x = 3;

            for (int i = 1; i < input.Length; i++)
            {
                if (x > input[1].Length - 1)
                {
                    x = x - input[1].Length;
                }
                string row = input[i];
                if (row[x].ToString() == "#")
                {
                    count++;
                }
                x += 3;
                
            }
            Console.WriteLine(count);
        }

        static void Part2() {
            string[] input = File.ReadAllLines("input.txt");
            
            Tuple<int, int>[] configs = 
            {
                Tuple.Create(1, 1),
                Tuple.Create(3, 1),
                Tuple.Create(5, 1),
                Tuple.Create(7, 1),
                Tuple.Create(1, 2),
            };

            foreach (Tuple<int, int> config in configs)
            {
                int x = config.Item1;
                int count = 0;
                for (int i = config.Item2; i < input.Length; i += config.Item2)
                {   
                    if (x > input[1].Length - 1)
                    {
                        x = x - input[1].Length;
                    }
                    string row = input[i];
                    if (row[x].ToString() == "#")
                    {
                        count++;
                    }
                    x += config.Item1;
                }
                Console.WriteLine(count);
            }
        }
    }
}
