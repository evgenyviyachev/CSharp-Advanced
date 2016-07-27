using System;
using System.Collections.Generic;

namespace Problem_15
{
    class RubixMatrix
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            int matrixRows = int.Parse(dimensions[0]);
            int matrixCols = int.Parse(dimensions[1]);
            Dictionary<int, List<int>> fullMatrix = new Dictionary<int, List<int>>();
            for (int i = 0; i < matrixRows; i++)
            {
                fullMatrix.Add(i, new List<int>());
                for (int j = 0; j < matrixCols; j++)
                {
                    fullMatrix[i].Add(matrixCols * i + j + 1);
                }
            }
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int rowColToBeSwapped = int.Parse(input[0]);
                string command = input[1];
                int moves = int.Parse(input[2]);
                if (command.Equals("down"))
                {
                    moves = moves % matrixRows;
                    List<int> temp = new List<int>();
                    List<int> temp2 = new List<int>();
                    for (int rows = matrixRows - moves; rows < matrixRows; rows++)
                    {
                        temp.Add(fullMatrix[rows][rowColToBeSwapped]);
                    }
                    for (int rows = 0; rows < matrixRows - moves; rows++)
                    {
                        temp2.Add(fullMatrix[rows][rowColToBeSwapped]);
                    }
                    for (int rows = moves; rows < matrixRows; rows++)
                    {
                        fullMatrix[rows][rowColToBeSwapped] = temp2[rows - moves];
                    }
                    for (int rows = 0; rows < moves; rows++)
                    {
                        fullMatrix[rows][rowColToBeSwapped] = temp[rows];
                    }
                }
                else if (command.Equals("up"))
                {
                    moves = moves % matrixRows;
                    List<int> temp = new List<int>();
                    List<int> temp2 = new List<int>();
                    for (int rows = moves; rows < matrixRows; rows++)
                    {
                        temp2.Add(fullMatrix[rows][rowColToBeSwapped]);
                    }
                    for (int rows = 0; rows < moves; rows++)
                    {
                        temp.Add(fullMatrix[rows][rowColToBeSwapped]);
                    }
                    for (int rows = matrixRows - moves; rows < matrixRows; rows++)
                    {
                        fullMatrix[rows][rowColToBeSwapped] = temp[rows - matrixRows + moves];
                    }
                    for (int rows = 0; rows < matrixRows - moves; rows++)
                    {
                        fullMatrix[rows][rowColToBeSwapped] = temp2[rows];
                    }
                }
                else if (command.Equals("left"))
                {
                    moves = moves % matrixCols;
                    List<int> temp = new List<int>();
                    List<int> temp2 = new List<int>();
                    for (int cols = moves; cols < matrixCols; cols++)
                    {
                        temp2.Add(fullMatrix[rowColToBeSwapped][cols]);
                    }
                    for (int cols = 0; cols < moves; cols++)
                    {
                        temp.Add(fullMatrix[rowColToBeSwapped][cols]);
                    }
                    for (int cols = matrixCols - moves; cols < matrixCols; cols++)
                    {
                        fullMatrix[rowColToBeSwapped][cols] = temp[cols - matrixCols + moves];
                    }
                    for (int cols = 0; cols < matrixCols - moves; cols++)
                    {
                        fullMatrix[rowColToBeSwapped][cols] = temp2[cols];
                    }
                }
                else if (command.Equals("right"))
                {
                    moves = moves % matrixCols;
                    List<int> temp = new List<int>();
                    List<int> temp2 = new List<int>();
                    for (int cols = matrixCols - moves; cols < matrixCols; cols++)
                    {
                        temp.Add(fullMatrix[rowColToBeSwapped][cols]);
                    }
                    for (int cols = 0; cols < matrixCols - moves; cols++)
                    {
                        temp2.Add(fullMatrix[rowColToBeSwapped][cols]);
                    }
                    for (int cols = moves; cols < matrixCols; cols++)
                    {
                        fullMatrix[rowColToBeSwapped][cols] = temp2[cols - moves];
                    }
                    for (int cols = 0; cols < moves; cols++)
                    {
                        fullMatrix[rowColToBeSwapped][cols] = temp[cols];
                    }
                }
            }
            int l = 0;
            for (int i = 0; i < matrixRows; i++)
            {
                for (int j = 0; j < matrixCols; j++)
                {
                    if (fullMatrix[i][j] == matrixCols * i + j + 1)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else {
                        for (int k = i; k < matrixRows; k++)
                        {
                            if (fullMatrix[k].Contains(matrixCols * i + j + 1))
                            {
                                l = fullMatrix[k].IndexOf(matrixCols * i + j + 1);
                                int temp = fullMatrix[k][l];
                                fullMatrix[k][l] = fullMatrix[i][j];
                                fullMatrix[i][j] = temp;
                                Console.WriteLine("Swap (" + i + ", " + j + ") with (" + k + ", " + l + ")");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}