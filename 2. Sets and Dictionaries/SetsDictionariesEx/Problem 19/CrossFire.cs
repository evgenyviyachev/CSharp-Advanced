using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_19
{
    class CrossFire
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<List<int>> matrixInt = new List<List<int>>();
            int rows = dimensions[0];
            int cols = dimensions[1];
            List<List<bool>> matrix = new List<List<bool>>();
            for (int i = 0; i < rows; i++)
            {
                matrixInt.Add(new List<int>());
                matrix.Add(new List<bool>());
                for (int j = 0; j < cols; j++)
                {
                    matrixInt[i].Add(j + 1 + i * cols);
                    matrix[i].Add(true);
                }
            }
            string s = Console.ReadLine();
            while (!s.Equals("Nuke it from orbit"))
            {
                string[] input = s.Split(' ');
                int currentRow = int.Parse(input[0]);
                int currentCol = int.Parse(input[1]);
                int radius = int.Parse(input[2]);
                int startRow = Math.Max(0, currentRow - radius);
                int endRow = Math.Min(currentRow + radius, matrix.Count - 1);
                int startCol = Math.Max(0, currentCol - radius);
                int endCol = -1;
                if (currentRow <= matrix.Count - 1 && currentRow >= 0)
                {
                    endCol = Math.Min(currentCol + radius, matrix[currentRow].Count - 1);
                }
                for (int i = startRow; i <= endRow; i++)
                {
                    try
                    {
                        matrix[i][currentCol] = false;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                for (int i = startCol; i <= endCol; i++)
                {
                    try
                    {
                        matrix[currentRow][i] = false;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Count; j++)
                    {
                        try
                        {
                            while (!matrix[i][j])
                            {
                                matrix[i].RemoveAt(j);
                                matrixInt[i].RemoveAt(j);
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count == 0)
                    {
                        matrix.RemoveAt(i);
                        matrixInt.RemoveAt(i);
                    }
                }
                s = Console.ReadLine();
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                string delim = "";
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(delim + matrixInt[i][j]);
                    delim = " ";
                }
                Console.WriteLine();
            }
        }
    }
}