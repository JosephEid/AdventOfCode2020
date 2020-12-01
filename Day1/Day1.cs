using System;
using System.IO;

namespace Day1
{
    class Day1
    {
        static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] != null)
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
                        goto InvalidOption;
                    }
                }
            } 
            else {
                goto InvalidOption;
            }
            InvalidOption: Console.WriteLine($"Please specify which part of the exercise you would like to run e.g dotnet run {"'1'"}");
        }

        static void Part1() {
            string[] input = File.ReadAllLines("input.txt");
            int? result = null;

            for (int x = 0; x < input.Length; x++)
            {
                int n1 = Int32.Parse(input[x]);
                for (int y = 0; y < input.Length; y++)
                {
                    if (x == y) continue;
                    int n2 = Int32.Parse(input[y]);
                    if (n1 + n2 == 2020)
                    {
                        result = n1 * n2;
                        Console.WriteLine($"{n1}, {n2}");
                        goto End;
                    } 
                }
            }
            End: Console.WriteLine(result);
        }

        static void Part2() {
            string[] input = File.ReadAllLines("input.txt");
            int? result = null;

            for (int x = 0; x < input.Length; x++)
            {
                int n1 = Int32.Parse(input[x]);
                for (int y = 0; y < input.Length; y++)
                {
                    if (x == y) continue;
                    int n2 = Int32.Parse(input[y]);
                    for (int z = 0; z < input.Length; z++)
                    {
                        if (x == z || y == z) continue;
                        int n3 = Int32.Parse(input[z]);
                        if (n1 + n2 + n3 == 2020)
                        {
                            result = n1 * n2 * n3;
                            Console.WriteLine($"{n1}, {n2}, {n3}");
                            goto End;
                        } 
                    }
                    
                }
            }
            End: Console.WriteLine(result);
        }
    }
}
