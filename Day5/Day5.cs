using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day5
{
    class Day5
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
            string[] input = File.ReadAllLines("input.txt");
            int maxId = 0;

            List<int> initRowRange = new List<int>();
            for (int i = 0; i <= 127; i++) initRowRange.Add(i);
            List<int> initColRange = new List<int>();
            for (int i = 0; i <= 7; i++) initColRange.Add(i);
            
            for (int i = 0; i < input.Length; i++)
            {
                string res = input[i];
                string row = res.Substring(0, 7);
                string col = res.Substring(7);
                List<int> rowRange = initRowRange;
                List<int> colRange = initColRange;
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == 'B') rowRange = rowRange.Skip(rowRange.Count / 2).ToList();
                    else if (row[j] == 'F') rowRange = rowRange.Take(rowRange.Count / 2).ToList();
                    else Console.WriteLine("Unrecognized char");
                }
                for (int k = 0; k < col.Length; k++)
                {
                    if (col[k] == 'R') colRange = colRange.Skip(colRange.Count / 2).ToList();
                    else if (col[k] == 'L') colRange = colRange.Take(colRange.Count / 2).ToList();
                    else Console.WriteLine("Unrecognized char");
                }
                int seatId = rowRange[0]*8 + colRange[0];
                if (seatId > maxId) maxId = seatId;
            }
            Console.WriteLine(maxId);
        }
    }
}
