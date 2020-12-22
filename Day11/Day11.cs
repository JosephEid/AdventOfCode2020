using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day11
{
    class Day11
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
            List<List<char>> state = new List<List<char>>();
            List<List<char>> newState = new List<List<char>>();

            for (int i = 0; i < input.Count(); i++)
            {
                state.Add(new List<char>());
                newState.Add(new List<char>());
                input[i].ToList().ForEach(x => state[i].Add(x));
                input[i].ToList().ForEach(x => newState[i].Add(x));
            }

            int width = state[0].Count();
            int height = state.Count();
            bool same = false;

            while (!same)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        char space = state[i][j];
                        char? n, s, w, e, ne, nw, se, sw;
                        n = s = w = e = ne = nw = se = sw = null;
                        
                        if (i+1 < height) n = state[i+1][j];
                        if (i-1 >= 0) s = state[i-1][j];
                        if (j+1 < width) e = state[i][j+1];
                        if (j-1 >= 0) w = state[i][j-1];
                        if (i+1 < height && j+1 < width) ne = state[i+1][j+1];
                        if (i-1 >= 0 && j+1 < width) se = state[i-1][j+1];
                        if (i+1 < height && j-1 >= 0) nw = state[i+1][j-1];
                        if (j-1 >= 0 && i-1 >= 0) sw = state[i-1][j-1];

                        List<char?> adj = new List<char?>()
                        {
                            n, s, e, w, ne, nw, se, sw
                        };
                        
                        if (space == 'L' && adj.All(x => x!='#'))
                            newState[i][j] = '#';

                        else if (space == '#' && adj.Where(x => x == '#').Count() >= 4)
                            newState[i][j] = 'L';
                    }
                }
                bool changeFound = false;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (state[i][j] != newState[i][j]) changeFound = true;
                        state[i][j] = newState[i][j];
                    }
                }

                int occ = 0;
                foreach (List<char> row in state) occ += row.Where(x => x.Equals('#')).Count();
                Console.WriteLine(occ);
                if (!changeFound) same = true;
            }
        }

        static void Part2()
        {
            List<string> input = File.ReadAllLines("input.txt").ToList();
            List<List<char>> state = new List<List<char>>();
            List<List<char>> newState = new List<List<char>>();

            for (int i = 0; i < input.Count(); i++)
            {
                state.Add(new List<char>());
                newState.Add(new List<char>());
                input[i].ToList().ForEach(x => state[i].Add(x));
                input[i].ToList().ForEach(x => newState[i].Add(x));
            }

            int width = state[0].Count();
            int height = state.Count();
            bool same = false;

            while (!same)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        char space = state[i][j];
                        char? n, s, w, e, ne, nw, se, sw;
                        n = s = w = e = ne = nw = se = sw = null;
                        
                        if (i+1 < height) n = GetSeat(state, i, j, 1, 0);
                        if (i-1 >= 0) s = GetSeat(state, i, j, -1, 0);
                        if (j+1 < width) e = GetSeat(state, i, j, 0, 1);
                        if (j-1 >= 0) w = GetSeat(state, i, j, 0, -1);
                        if (i+1 < height && j+1 < width) ne = GetSeat(state, i, j, 1, 1);
                        if (i-1 >= 0 && j+1 < width) se = GetSeat(state, i, j, -1, 1);
                        if (i+1 < height && j-1 >= 0) nw = GetSeat(state, i, j, 1, -1);
                        if (j-1 >= 0 && i-1 >= 0) sw = GetSeat(state, i, j, -1, -1);

                        List<char?> adj = new List<char?>()
                        {
                            n, s, e, w, ne, nw, se, sw
                        };
                        
                        if (space == 'L' && adj.All(x => x!='#'))
                            newState[i][j] = '#';

                        else if (space == '#' && adj.Where(x => x == '#').Count() >= 5)
                            newState[i][j] = 'L';
                    }
                }
                bool changeFound = false;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (state[i][j] != newState[i][j]) changeFound = true;
                        state[i][j] = newState[i][j];
                    }
                }

                int occ = 0;
                foreach (List<char> row in state) occ += row.Where(x => x.Equals('#')).Count();
                Console.WriteLine(occ);
                if (!changeFound) same = true;
            }
        }
        
        static char? GetSeat(List<List<char>> state, int y, int x, int yDir, int xDir)
        {
            if (y+yDir >= 0 && y+yDir < state.Count() && x+xDir >= 0 && x+xDir < state[0].Count())
            {
                if (state[y+yDir][x+xDir] != '.') return state[y+yDir][x+xDir];
                else return GetSeat(state, y+yDir, x+xDir, yDir, xDir);
            }
            return null;
        }
    }
}
