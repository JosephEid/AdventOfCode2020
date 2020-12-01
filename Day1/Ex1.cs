using System;
using System.IO;

namespace Day1
{
    class Ex1
    {
        static void Main(string[] args)
        {
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
    }
}
