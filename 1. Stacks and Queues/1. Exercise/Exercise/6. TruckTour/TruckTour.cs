using System;
using System.Linq;

namespace _6.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int pumps = int.Parse(Console.ReadLine());
            long[] pumpLiters = new long[pumps];
            long[] pumpKmsToNext = new long[pumps];

            for (int i = 0; i < pumps; i++)
            {
                long[] pumpData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                pumpLiters[i] = pumpData[0];
                pumpKmsToNext[i] = pumpData[1];
            }

            long currentPetrolKms = 0;
            long kmsCovered = 0;
            bool found = true;

            for (int i = 0; i < pumps; i++)
            {
                currentPetrolKms -= kmsCovered;
                currentPetrolKms += pumpLiters[i];
                if (pumpKmsToNext[i] > currentPetrolKms)
                {
                    found = false;
                    break;
                }
                kmsCovered = pumpKmsToNext[i];
            }

            if (found && currentPetrolKms >= pumpKmsToNext[pumps - 1])
            {
                Console.WriteLine(0);
                return;
            }            

            for (int i = 1; i < pumps; i++)
            {
                kmsCovered = 0;
                currentPetrolKms = 0;
                found = true;

                for (int j = i; j < pumps; j++)
                {
                    currentPetrolKms -= kmsCovered;
                    currentPetrolKms += pumpLiters[j];
                    if (pumpKmsToNext[j] > currentPetrolKms)
                    {
                        found = false;
                        break;
                    }
                    kmsCovered = pumpKmsToNext[j];
                }

                if (found && currentPetrolKms >= pumpKmsToNext[pumps - 1])
                {
                    for (int j = 0; j < i; j++)
                    {
                        currentPetrolKms -= kmsCovered;
                        currentPetrolKms += pumpLiters[j];
                        if (pumpKmsToNext[j] > currentPetrolKms)
                        {
                            found = false;
                            break;
                        }
                        kmsCovered = pumpKmsToNext[j];
                    }
                   
                    if (found && currentPetrolKms >= pumpKmsToNext[i - 1])
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
            }
        }
    }
}