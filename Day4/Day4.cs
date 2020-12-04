using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Day4
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
            List<string> passports = new List<string>();

            string builder = "";

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                builder += $"{line} ";
                if (String.IsNullOrEmpty(line) || i == input.Length - 1)
                {
                    passports.Add(builder);
                    builder = "";
                }
            }

            int count = 0;

            foreach (string passport in passports)
            {
                if (passport.Contains("byr:") &&
                    passport.Contains("iyr:") &&
                    passport.Contains("eyr:") &&
                    passport.Contains("hgt:") &&
                    passport.Contains("hcl:") &&
                    passport.Contains("ecl:") &&
                    passport.Contains("pid:"))
                {
                    count ++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
