using System;

namespace Problem_21
{
    class ParkingSystem
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            bool[,] parking = new bool[int.Parse(dimensions[0]), int.Parse(dimensions[1])];
            string s = Console.ReadLine();
            while (!s.Equals("stop"))
            {
                string[] entryRowPositionXY = s.Split(' ');
                int entryRow = int.Parse(entryRowPositionXY[0]);
                int row = int.Parse(entryRowPositionXY[1]);
                int col = int.Parse(entryRowPositionXY[2]);
                int countOfMoves = Math.Abs(entryRow - row) + 1;
                if (parking[row, col] == false)
                {
                    countOfMoves += col;
                    parking[row, col] = true;
                    Console.WriteLine(countOfMoves);
                }
                else {
                    int colNew = 0;
                    int min = int.MaxValue;
                    for (int i = 1; i < int.Parse(dimensions[1]); i++)
                    {
                        if (parking[row, i] == false && Math.Abs(col - i) < min)
                        {
                            min = Math.Abs(col - i);
                            colNew = i;
                        }
                    }
                    if (colNew == 0)
                    {
                        Console.WriteLine($"Row {row} full");
                    }
                    else {
                        countOfMoves += colNew;
                        parking[row, colNew] = true;
                        Console.WriteLine(countOfMoves);
                    }
                }
                s = Console.ReadLine();
            }
        }
    }
}