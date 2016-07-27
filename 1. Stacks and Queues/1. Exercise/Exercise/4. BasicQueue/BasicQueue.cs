using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.BasicQueue
{
    class BasicQueue
    {
        static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ');
            var numbersInQueue = new Queue<int>();
            string[] numbers = Console.ReadLine().Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersInQueue.Enqueue(int.Parse(numbers[i]));
            }

            int numbersToDequeue = int.Parse(elements[1]);

            if (numbersToDequeue >= numbersInQueue.Count)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbersToDequeue; i++)
            {
                numbersInQueue.Dequeue();
            }

            int numberToCheck = int.Parse(elements[2]);

            if (numbersInQueue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersInQueue.Min());
            }
        }
    }
}