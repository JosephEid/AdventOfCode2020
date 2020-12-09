using System;
using System.IO;
using System.Collections.Generic;

namespace Day8
{
    class Day8
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
            List<int> visited = new List<int>();
            int acc = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (visited.Contains(i)) goto End;
                visited.Add(i);
                string[] split = input[i].Split(" ");
                string sign = split[1].Substring(0, 1);
                string numS = split[1].Substring(1);
                int num = Int32.Parse(numS);
                switch (split[0])
                {
                    case "nop": 
                        continue;
                    case "acc":
                        acc = sign == "+" ? acc + num : acc - num;
                        break;
                    case "jmp":
                        i = sign == "+" ? i + num - 1 : i - num - 1;
                        break;
                }
            }
            End: Console.WriteLine(acc);
        }

        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<int> jmpNop = new List<int>();
            for (int h = 0; h < input.Length; h++) {
                string[] split = input[h].Split(" ");
                if (split[0] == "nop" || split[0] == "jmp") jmpNop.Add(h);
            }
            foreach (int loc in jmpNop)
            {
                int acc = 0;
                int loopCount = 0;
                List<int> visited = new List<int>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (i == input.Length - 1)
                    {
                        Console.WriteLine(acc);
                        goto Found;
                    } 
                    if (visited.Contains(i)) break;
                    if (loopCount > input.Length -1) break;
                    visited.Add(i);
                    
                    string[] split = input[i].Split(" ");
                    string action = split[0];
                    if (i == loc)
                    {
                        action = action =="jmp" ? "nop" : "jmp";
                    }
                    string sign = split[1].Substring(0, 1);
                    string numS = split[1].Substring(1);
                    int num = Int32.Parse(numS);
                    switch (action)
                    {
                        case "nop": 
                            continue;
                        case "acc":
                            acc = sign == "+" ? acc + num : acc - num;
                            break;
                        case "jmp":
                            i = sign == "+" ? i + num - 1 : i - num - 1;
                            break;
                    }
                }
            }
            Found: Console.WriteLine("Result found ^");
        }
    }
}
