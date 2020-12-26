using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    class Day12
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

            int ewPos = 0;
            int nsPos = 0;
            int dir = 0;

            foreach (string line in input)
            {
                string cmd = line.Substring(0,1);
                int val = Int32.Parse(line.Substring(1));
                dir = dir % 360;
                switch (cmd)
                {
                    case "N":
                        nsPos += val;
                        break;
                    case "S":
                        nsPos -= val;
                        break;
                    case "E":
                        ewPos += val;
                        break;
                    case "W":
                        ewPos -= val;
                        break;
                    case "R":
                        Console.WriteLine($"Current dir: {dir}, going R {val}");
                        dir += val;
                        Console.WriteLine($"Now facing: {dir}");
                        break;
                    case "L":
                        Console.WriteLine($"Current dir: {dir}, going L {val}");
                        dir -= val;
                        Console.WriteLine($"Now facing: {dir}");
                        break;
                    case "F":
                        switch (dir)
                        {
                            case 0:
                                ewPos += val;
                                break;
                            case 90:
                                nsPos -= val;
                                break;
                            case 180:
                                ewPos -= val;
                                break;
                            case 270:
                                nsPos += val;
                                break;
                            case -90:
                                nsPos += val;
                                break;
                            case -180:
                                ewPos -= val;
                                break;
                            case -270:
                                nsPos -= val;
                                break;
                        }
                        break;
                    
                }
            }
            Console.WriteLine(Math.Abs(nsPos) + Math.Abs(ewPos));
        }

        static void Part2()
        {
            List<string> input = File.ReadAllLines("input.txt").ToList();

            int ewPos = 0;
            int nsPos = 0;
            int dir = 0;

            foreach (string line in input)
            {
                string cmd = line.Substring(0,1);
                int val = Int32.Parse(line.Substring(1));
                dir = dir % 360;
                switch (cmd)
                {
                    case "N":
                        nsPos += val;
                        break;
                    case "S":
                        nsPos -= val;
                        break;
                    case "E":
                        ewPos += val;
                        break;
                    case "W":
                        ewPos -= val;
                        break;
                    case "R":
                        Console.WriteLine($"Current dir: {dir}, going R {val}");
                        dir += val;
                        Console.WriteLine($"Now facing: {dir}");
                        break;
                    case "L":
                        Console.WriteLine($"Current dir: {dir}, going L {val}");
                        dir -= val;
                        Console.WriteLine($"Now facing: {dir}");
                        break;
                    case "F":
                        switch (dir)
                        {
                            case 0:
                                ewPos += val;
                                break;
                            case 90:
                                nsPos -= val;
                                break;
                            case 180:
                                ewPos -= val;
                                break;
                            case 270:
                                nsPos += val;
                                break;
                            case -90:
                                nsPos += val;
                                break;
                            case -180:
                                ewPos -= val;
                                break;
                            case -270:
                                nsPos -= val;
                                break;
                        }
                        break;
                    
                }
            }
            Console.WriteLine(Math.Abs(nsPos) + Math.Abs(ewPos));
        }
    }
}