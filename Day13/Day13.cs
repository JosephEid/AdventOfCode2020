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
            List<string> input = File.ReadAllLines("input.txt").ToList();
            int timestamp = Int32.Parse(input[0]);
            List<int> busIds = input[1].Split(",").Where(x => x != "x").Select(x => Int32.Parse(x)).ToList();
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

        static void Part2()
        {
            List<string> input = File.ReadAllLines("input.txt").ToList();
            List<string> busIds = input[1].Split(",").ToList();
            int max = 0;
            List<Int64> indexes = busIds.Where(x => x != "x").Select(x => (Int64)busIds.IndexOf(x)).ToList();
            indexes.ForEach(x => Console.WriteLine(x));
            Int64 first = Int64.Parse(busIds.First());
            Int64 start = 0;
            for (Int64 i = 100000000000000; i < Single.PositiveInfinity; i++)
            {
                if (i % first == 0) 
                {
                    start = i;
                    Console.WriteLine($"Start found: {start}");
                    goto Start;
                }
            }
            Start: for (Int64 t = start; t < Single.PositiveInfinity; t += first)
            {
                if (t%10000000 == 0) Console.WriteLine(t);
                int count = 0;
                for (int j = 1; j < indexes.Count(); j++)
                {
                    Int64 multiple = Int64.Parse(busIds[(int)indexes[j]]);
                    if ((t + indexes[j]) % multiple == 0) count++;
                    else break;
                }
                if (count == indexes.Count()-1) 
                {
                    Console.WriteLine($"Match found: {t} {max}");
                    goto End;
                }
            }

            End: Console.WriteLine("");
        }
    }
}
