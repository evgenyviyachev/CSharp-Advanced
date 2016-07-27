using System;
using System.Linq;
using System.Numerics;

namespace Problem_02
{
    class CubicsRube
    {
        static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int freeCells = dimension * dimension * dimension;
            BigInteger particlesSum = 0;

            while (input != "Analyze")
            {
                long[] currentCoords = input.Trim().Split().Select(long.Parse).ToArray();
                bool isInside = true;
                for (int i = 0; i < currentCoords.Length - 1; i++)
                {
                    if (currentCoords[i] > dimension - 1 || currentCoords[i] < 0)
                    {
                        isInside = false;
                        break;
                    }
                }

                if (isInside && currentCoords[3] != 0)
                {
                    freeCells--;
                    particlesSum += currentCoords[3];
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(particlesSum);
            Console.WriteLine(freeCells);
        }
    }
}