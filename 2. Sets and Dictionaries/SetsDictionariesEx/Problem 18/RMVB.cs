using System;
using System.Linq;

namespace Problem_18
{
    class RMVB
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int playerRow = 0;
            int playerCol = 0;
            bool playerDied = false;
            bool playerEscaped = false;
            bool[,] matrix = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    if (currentRow[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                        matrix[i, j] = false;
                    }
                    else if (currentRow[j] == '.')
                    {
                        matrix[i, j] = false;
                    }
                    else
                    {
                        matrix[i, j] = true;
                    }
                }
            }
            char[] commands = Console.ReadLine().ToCharArray();
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'R')
                {
                    if (playerCol < cols - 1)
                    {
                        playerCol = playerCol + 1;
                        if (matrix[playerRow, playerCol])
                        {
                            playerDied = true;
                        }
                    }
                    else
                    {
                        playerEscaped = true;
                    }
                }
                else if (commands[i] == 'L')
                {
                    if (playerCol > 0)
                    {
                        playerCol = playerCol - 1;
                        if (matrix[playerRow, playerCol])
                        {
                            playerDied = true;
                        }
                    }
                    else
                    {
                        playerEscaped = true;
                    }
                }
                else if (commands[i] == 'U')
                {
                    if (playerRow > 0)
                    {
                        playerRow = playerRow - 1;
                        if (matrix[playerRow, playerCol])
                        {
                            playerDied = true;
                        }
                    }
                    else
                    {
                        playerEscaped = true;
                    }
                }
                else
                {
                    if (playerRow < rows - 1)
                    {
                        playerRow = playerRow + 1;
                        if (matrix[playerRow, playerCol])
                        {
                            playerDied = true;
                        }
                    }
                    else
                    {
                        playerEscaped = true;
                    }
                }
                bool[,] matrixCurrent = new bool[rows, cols];
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        matrixCurrent[j, k] = matrix[j, k];
                    }
                }
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        if (matrixCurrent[j, k])
                        {
                            if (j > 0)
                            {
                                matrix[j - 1, k] = true;
                            }
                            if (j < rows - 1)
                            {
                                matrix[j + 1, k] = true;
                            }
                            if (k > 0)
                            {
                                matrix[j, k - 1] = true;
                            }
                            if (k < cols - 1)
                            {
                                matrix[j, k + 1] = true;
                            }
                        }
                    }
                }
                if (matrix[playerRow, playerCol])
                {
                    playerDied = true;
                }
                if (playerDied || playerEscaped)
                {
                    break;
                }
            }
            if (playerDied)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j])
                        {
                            Console.Write("B");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                return;
            }
            if (playerEscaped)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j])
                        {
                            Console.Write("B");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }
    }
}