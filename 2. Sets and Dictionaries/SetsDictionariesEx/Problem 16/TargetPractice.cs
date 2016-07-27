using System;
using System.Text;

namespace Problem_16
{
    class TargetPractice
    {
        static char[,] FillPattern(string inputSnake, int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            char[] snake = inputSnake.ToCharArray();
            if (matrix.GetLength(0) * matrix.GetLength(1) > inputSnake.Length)
            {
                double multiplier = Math.Ceiling(Convert.ToDouble(matrix.GetLength(0) * matrix.GetLength(1)) / inputSnake.Length);
                StringBuilder sb = new StringBuilder(inputSnake);
                for (int i = 0; i < multiplier - 1; i++)
                {
                    sb.Append(inputSnake);
                }
                snake = sb.ToString().ToCharArray();
            }

            for (int i = matrix.GetLength(0) - 1; i >= 0; i -= 2)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[(matrix.GetLength(0) - 1 - i) * matrix.GetLength(1) + matrix.GetLength(1) - 1 - j];
                }
            }
            for (int i = matrix.GetLength(0) - 2; i >= 0; i -= 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = snake[(matrix.GetLength(0) - 1 - i) * matrix.GetLength(1) + j];
                }
            }
            return matrix;
        }

        static void MatrixFallingDown(char[,] lettersFirst)
        {
            int a = 0;
            while (a < 12)
            {

                for (int j = 0; j < lettersFirst.GetLength(1); j++)
                {
                    for (int i = lettersFirst.GetLength(0) - 1; i >= 0; i--)
                    {
                        if (lettersFirst[i, j] == ' ')
                        {
                            for (int k = i; k > 0; k--)
                            {
                                lettersFirst[k, j] = lettersFirst[k - 1, j];
                            }
                            lettersFirst[0, j] = ' ';
                        }
                    }
                }
                a++;
            }
            for (int i = 0; i < lettersFirst.GetLength(0); i++)
            {
                for (int j = 0; j < lettersFirst.GetLength(1); j++)
                {
                    Console.Write(lettersFirst[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            //char[] inputSnake = Console.ReadLine().ToCharArray();
            string inputSnake = Console.ReadLine();
            string[] shot = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
            int shotRow = int.Parse(shot[0]);
            int shotCol = int.Parse(shot[1]);
            int shotRadius = int.Parse(shot[2]);
            char[,] matrix = FillPattern(inputSnake, rows, cols);

            matrix[shotRow, shotCol] = ' ';

            int nearRight = Math.Min(shotRadius, cols - 1 - shotCol);
            int nearLeft = Math.Min(shotRadius, shotCol);

            for (int j = shotCol + 1; j <= shotCol + nearRight; j++)
            {
                matrix[shotRow, j] = ' ';
            }
            for (int j = shotCol - 1; j >= shotCol - nearLeft; j--)
            {
                matrix[shotRow, j] = ' ';
            }

            int nearDown = Math.Min(shotRadius, rows - 1 - shotRow);
            int nearUp = Math.Min(shotRadius, shotRow);

            for (int i = shotRow + 1; i <= shotRow + nearDown; i++)
            {
                matrix[i, shotCol] = ' ';
            }
            for (int i = shotRow - 1; i >= shotRow - nearUp; i--)
            {
                matrix[i, shotCol] = ' ';
            }

            int nearLeftUp = Math.Min(nearLeft, nearUp);
            int nearRightUp = Math.Min(nearRight, nearUp);
            int nearLeftDown = Math.Min(nearLeft, nearDown);
            int nearRightDown = Math.Min(nearRight, nearDown);
            for (int i = shotRow - 1, j = shotCol - 1; i >= shotRow - nearLeftUp + 1; i--, j--)
            {
                if (j == shotRow - nearLeftUp + 1)
                {
                    matrix[i, j] = ' ';
                    continue;
                }
                matrix[i, j] = ' ';
            }
            for (int i = shotRow - 1, j = shotCol + 1; i >= shotRow - nearRightUp + 1; i--, j++)
            {
                if (j == shotRow + nearRightUp - 1)
                {
                    matrix[i, j] = ' ';
                    continue;
                }
                matrix[i, j] = ' ';
            }
            for (int i = shotRow + 1, j = shotCol - 1; i <= shotRow + nearLeftDown - 1; i++, j--)
            {
                if (j == shotRow - nearLeftDown + 1)
                {
                    matrix[i, j] = ' ';
                    continue;
                }
                matrix[i, j] = ' ';
            }
            for (int i = shotRow + 1, j = shotCol + 1; i <= shotRow + nearRightDown - 1; i++, j++)
            {
                if (j == shotRow + nearRightDown - 1)
                {
                    matrix[i, j] = ' ';
                    continue;
                }
                matrix[i, j] = ' ';
            }

            MatrixFallingDown(matrix);
        }
    }
}