using System;
using System.Collections.Generic;
using System.IO;

namespace Day7
{
    class Day7
    {
        public static Dictionary<string, List<Tuple<string, int>>> rules = new Dictionary<string, List<Tuple<string, int>>>();

        static void Main(string[] args)
        {
            rules = new Dictionary<string, List<Tuple<string, int>>>();
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

            foreach (string l in input)
            {
                string[] splitL = l.Split(" bags contain ");
                string colour = splitL[0];
                string contents = splitL[1];

                if (contents == "no other bags.") rules.Add(colour, null);
                else
                {
                    string[] contSplit = contents.Split(", ");
                    List<Tuple<string, int>> contArray = new List<Tuple<string, int>>();
                    foreach (string c in contSplit)
                    {
                        string[] cSplit = c.Split(" ");
                        contArray.Add(Tuple.Create($"{cSplit[1]} {cSplit[2]}", Int32.Parse(cSplit[0])));
                    }
                    rules.Add(colour, contArray);
                }
            }

            int count = 0;

            foreach (var kvp in rules)
            {
                bool found = findGold(kvp.Key);
                if (found) count ++;
            }
            Console.WriteLine(count);
        }

        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");

            foreach (string l in input)
            {
                string[] splitL = l.Split(" bags contain ");
                string colour = splitL[0];
                string contents = splitL[1];

                if (contents == "no other bags.") rules.Add(colour, null);
                else
                {
                    string[] contSplit = contents.Split(", ");
                    List<Tuple<string, int>> contArray = new List<Tuple<string, int>>();
                    foreach (string c in contSplit)
                    {
                        string[] cSplit = c.Split(" ");
                        contArray.Add(Tuple.Create($"{cSplit[1]} {cSplit[2]}", Int32.Parse(cSplit[0])));
                    }
                    rules.Add(colour, contArray);
                }
            }

            int count = 0;

            count += getChildCount("shiny gold");
            Console.WriteLine(count);
        }

        static int getChildCount(string key)
        {
            int count = 0;
            int bagCount = 0;
            int childrenCount = 0;
            var value = rules[key];
            if (value == null) return 0;
            foreach (var cont in value)
            {
                bagCount += cont.Item2;
                childrenCount += getChildCount(cont.Item1)*cont.Item2;
            }
            count += bagCount;
            count += childrenCount;
            return count;
        }

        static bool findGold(string key)
        {
            var value = rules[key];
            if (value == null) return false;
            foreach (var v in value)
            {
                if (v.Item1 == "shiny gold") return true;
                else
                {
                    if (findGold(v.Item1))
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
        }
    }
}
