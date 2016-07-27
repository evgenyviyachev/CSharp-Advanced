using System;
using System.Collections.Generic;

namespace Problem_17
{
    class LegoBlocks
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int doubledRows = 2 * rows;
            List<string>[] lines = new List<string>[doubledRows];
            for (int i = 0; i < doubledRows; i++)
            {
                string[] line = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                lines[i] = new List<string>();
                for (int j = 0; j < line.Length; j++)
                {
                    lines[i].Add(line[j]);
                }
            }
            int targetCols = lines[0].Count + lines[rows].Count;
            int numberOfCells = 0;
            bool match = true;
            string[][] fullMatrix = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                numberOfCells += (lines[i].Count + lines[rows + i].Count);
                if (lines[i].Count + lines[rows + i].Count != targetCols)
                {
                    match = false;
                    continue;
                }
                if (match)
                {
                    fullMatrix[i] = new string[targetCols];
                    for (int j = 0; j < lines[i].Count; j++)
                    {
                        fullMatrix[i][j] = lines[i][j];
                    }
                    for (int j = lines[i + rows].Count - 1; j >= 0; j--)
                    {
                        fullMatrix[i][targetCols - j - 1] = lines[i + rows][j];
                    }
                }                
            }
            if (!match)
            {
                Console.WriteLine("The total number of cells is: " + numberOfCells);
            }
            else {
                for (int i = 0; i < rows; i++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ", fullMatrix[i]));
                    Console.WriteLine("]");
                }
            }
        }
    }
}