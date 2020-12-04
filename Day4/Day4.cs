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

        static void Part2() {
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
                    string[] split = passport.Trim().Split(" ");
                    List<Tuple<string, string>> fields = new List<Tuple<string, string>>();
                    foreach (string s in split)
                    {
                        string[] fieldSplit = s.Split(":");
                        fields.Add(Tuple.Create(fieldSplit[0], fieldSplit[1]));
                    }
                    bool valid = true;
                    foreach (Tuple<string, string> f in fields)
                    {
                        try
                        {
                            switch (f.Item1)
                            {
                                case "byr":
                                    int year  = Int32.Parse(f.Item2);
                                    if (!(year >= 1920 && Int32.Parse(f.Item2) <= 2002)) valid = false;
                                    break;
                                case "iyr":
                                    year  = Int32.Parse(f.Item2);
                                    if (!(year >= 2010 && Int32.Parse(f.Item2) <= 2020)) valid = false;
                                    break;
                                case "eyr":
                                    year  = Int32.Parse(f.Item2);
                                    if (!(year >= 2020 && Int32.Parse(f.Item2) <= 2030)) valid = false;
                                    break;
                                case "hgt":
                                    if (f.Item2.Contains("cm"))
                                    {
                                        string[] valueSplit = f.Item2.Split("cm");
                                        int value = Int32.Parse(valueSplit[0]);
                                        if (!(value >= 150 && value <= 193))
                                        {
                                            valid = false;
                                        }
                                    }
                                    else if (f.Item2.Contains("in"))
                                    {
                                        string[] valueSplit = f.Item2.Split("in");
                                        int value = Int32.Parse(valueSplit[0]);
                                        if (!(value >= 59 && value <= 76))
                                        {
                                            valid = false;
                                        }
                                    }
                                    else
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "hcl":
                                    if (f.Item2.Contains("#"))
                                    {
                                        string[] valueSplit = f.Item2.Split("#");
                                        string value = valueSplit[1];
                                        string allowedChars = "abcdef0123456789";
                                        bool onlyAllowedChar = value.All(c => allowedChars.Contains(c));
                                        if (!(onlyAllowedChar && value.Length == 6))
                                        {
                                            valid = false;
                                        }
                                    }
                                    else
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "ecl":
                                    string c = f.Item2;
                                    if (!(c == "amb" || c == "blu" || c == "brn" || c == "gry" || c == "grn" || c == "hzl" || c == "oth"))
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "pid":
                                    int number = Int32.Parse(f.Item2);
                                    if (!(f.Item2.Length == 9))
                                    {
                                        valid = false;
                                    }
                                    break;

                            }
                        }
                        catch (System.Exception e)
                        {
                            valid = false;
                            Console.WriteLine(e.Message);
                        }
                    }
                    Console.WriteLine(valid);
                    if (valid) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
