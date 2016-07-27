using System;
using System.Collections.Generic;

namespace _5.QueueSequence
{
    class QueueSequence
    {
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            var sequence = new Queue<long>();
            sequence.Enqueue(N);
            int count = 0;
            List<long> numbers = new List<long>();

            var sequence2 = new Queue<long>();
            sequence2.Enqueue(N);
            numbers.Add(sequence2.Dequeue());

            while (sequence.Count < 50)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        sequence.Enqueue(numbers[count] + 1);
                        sequence2.Enqueue(numbers[count] + 1);
                        if (sequence.Count == 50)
                        {
                            break;
                        }
                    }
                    else if (i == 1)
                    {
                        sequence.Enqueue(2 * numbers[count] + 1);
                        sequence2.Enqueue(2 * numbers[count] + 1);
                        if (sequence.Count == 50)
                        {
                            break;
                        }
                    }
                    else
                    {
                        sequence.Enqueue(numbers[count] + 2);
                        sequence2.Enqueue(numbers[count] + 2);
                        if (sequence.Count == 50)
                        {
                            break;
                        }
                    }
                }
                count++;
                numbers.Add(sequence2.Dequeue());
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}